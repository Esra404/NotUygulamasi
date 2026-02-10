using NotUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



namespace NotUygulamasi
{

    class Program
    {
        static List<User> users = new List<User>();
        
        static List<Note> notes = new List<Note>();
        static User aktifKullanici = null;
        static int noteIdCounter = 1;
        static int userIdCounter = 1;
        static string notesFile = "notes.json";
        static string usersFile = "users.json";





        static void Main(string[] args)
        {
            KullanicilariYukle();
            NotlariYukle();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("===========================");
                Console.WriteLine("   NOT UYGULAMASI");
                Console.WriteLine("===========================\n");

                Console.WriteLine("1 - Kayıt Ol");
                Console.WriteLine("2 - Giriş Yap");
                Console.WriteLine("0 - Çıkış\n");

                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        KayitOl();
                        break;

                    case "2":
                        GirisYap();
                        break;


                    case "0":
                        Console.WriteLine("\nÇıkış yapılıyor...");
                        return;

                    default:
                        Console.WriteLine("\nHatalı seçim, tekrar dene!");
                        Bekle();
                        break;
                }
            }
        }
        static void KayitOl()
        {

            Console.Clear();
            Console.WriteLine("--- KAYIT OL ---\n");

            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();

            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            users.Add(new User
            {
                Id = userIdCounter++,
                Username = username,
                Password = password
            });

            Console.WriteLine("\nKayıt başarılı!");
            Bekle();
            KullanicilariKaydet();

        }

        static void GirisYap()
        {
            Console.Clear();
            Console.WriteLine("--- GİRİŞ YAP ---\n");

            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();

            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    aktifKullanici = user;
                    Console.WriteLine($"\nGiriş başarılı! Hoş geldin {user.Username} 😎");
                    Bekle();
                    NotMenusu();
                    return;
                }
            }

            Console.WriteLine("\nHatalı kullanıcı adı veya şifre!");
            Bekle();
        }

        static void NotMenusu()
        {
            while (aktifKullanici != null)
            {
                Console.Clear();

                Console.WriteLine("===========================");
                Console.WriteLine($" HOŞ GELDİN {aktifKullanici.Username}");
                Console.WriteLine("===========================\n");

                Console.WriteLine("1 - Not Ekle");
                Console.WriteLine("2 - Notlarımı Listele");
                Console.WriteLine("3 - Not Güncelle");
                Console.WriteLine("4 - Not Sil");
                Console.WriteLine("5 - Çıkış Yap");


                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        NotEkle();
                        break;

                    case "2":
                        NotlariListele();
                        break;


                    case "3":
                        NotGuncelle();
                        break;
                    case "4":
                        NotSil();
                        break;

                    case "5":
                        aktifKullanici = null;
                        Console.WriteLine("\nÇıkış yapıldı.");
                        Bekle();
                        break;

                        //case "3":
                        //    aktifKullanici = null;
                        //    Console.WriteLine("\nÇıkış yapıldı.");
                        //    Bekle();
                        //    break;

                        //default:
                        //    Console.WriteLine("\nHatalı seçim!");
                        //    Bekle();
                        //    break;
                }
            }
        }



        static void Bekle()
        {
            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
            Console.ReadKey();
        }
        static void NotEkle()
        {
            Console.Clear();
            Console.WriteLine("--- NOT EKLE ---\n");

            Console.Write("Başlık: ");
            string title = Console.ReadLine();

            Console.Write("İçerik: ");
            string content = Console.ReadLine();

            notes.Add(new Note
            {
                Id = noteIdCounter++,
                Title = title,
                Content = content,
                User = aktifKullanici
            });

            Console.WriteLine("\nNot eklendi!");
            Bekle();
            NotlariKaydet();

        }
        static void NotlariListele()
        {
            Console.Clear();
            Console.WriteLine("--- NOTLARIM ---\n");

            bool notVarMi = false;

            foreach (var note in notes)
            {
                if (note.User.Id == aktifKullanici.Id)
                {
                    Console.WriteLine($"ID: {note.Id}");
                    Console.WriteLine($"Başlık: {note.Title}");
                    Console.WriteLine($"İçerik: {note.Content}");
                    Console.WriteLine("-------------------");
                    notVarMi = true;
                }
            }

            if (!notVarMi)
            {
                Console.WriteLine("Henüz notun yok 😅");
            }

            Bekle();
        }
        static void NotSil()
        {
            Console.Clear();
            Console.WriteLine("--- NOT SİL ---\n");

            Console.Write("Silmek istediğin notun ID'si: ");
            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID sayı olacak hacı 😅");
                Bekle();
                return;
            }

            Note silinecekNot = null;

            foreach (var note in notes)
            {
                if (note.Id == id && note.User.Id == aktifKullanici.Id)
                {
                    silinecekNot = note;
                    break;
                }
            }

            if (silinecekNot == null)
            {
                Console.WriteLine("Böyle bir not yok ya da sana ait değil 🤨");
            }
            else
            {
                notes.Remove(silinecekNot);
                Console.WriteLine("Not uçtu gitti 🗑️");
            }

            Bekle();
            NotlariKaydet();

        }
        static void NotlariKaydet()
        {
            var json = JsonSerializer.Serialize(notes);
            File.WriteAllText(notesFile, json);
        }
        static void KullanicilariKaydet()
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(usersFile, json);
        }
        static void KullanicilariYukle()
        {
            if (File.Exists(usersFile))
            {
                var json = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
        }


        static void NotlariYukle()
        {
            if (File.Exists(notesFile))
            {
                var json = File.ReadAllText(notesFile);
                notes = JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();

                if (notes.Count > 0)
                    noteIdCounter = notes[^1].Id + 1;
            }
        }
        static void NotGuncelle()
        {
            Console.Clear();
            Console.WriteLine("--- NOT GÜNCELLE ---\n");

            Console.Write("Güncellenecek not ID: ");
            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID sayı olmalı bro 😅");
                Bekle();
                return;
            }

            foreach (var note in notes)
            {
                if (note.Id == id && note.User.Id == aktifKullanici.Id)
                {
                    Console.Write("Yeni Başlık: ");
                    note.Title = Console.ReadLine();

                    Console.Write("Yeni İçerik: ");
                    note.Content = Console.ReadLine();

                    NotlariKaydet();

                    Console.WriteLine("\nNot güncellendi 🔧");
                    Bekle();
                    return;
                }
            }

            Console.WriteLine("Not bulunamadı ya da sana ait değil 🤷‍♀️");
            Bekle();
        }


    }
}
