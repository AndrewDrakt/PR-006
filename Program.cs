using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;
using Практ6;

namespace Практ6
{
    internal class Program
    {
        static void Main()
        {
            Fele subject = new Fele();
            subject.prym = "Прямоугольник";
            subject.dlin = 14;
            subject.shir = 15;
            subject.sqr = "Квадрат";
            subject.dlin1 = 10;
            subject.shir1 = 10;
            subject.prym1 = "Прямоугольник";
            subject.dlin2 = 22;
            subject.shir2 = 20;

            Console.WriteLine("Введите путь до файла(вместе с расширением), который вы хотите открыть");
            string put = Console.ReadLine();
            if (File.Exists(put))
            {
                Console.Clear();
                Console.WriteLine("Чтобы сохранить файл в одном из форматов, нажмите клавишу F1, для отмены нажмите Escape");
                string txt = File.ReadAllText(put);
                Console.Write(txt);
                ConsoleKeyInfo com;
                com = Console.ReadKey();
                if (com.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите название файла(вместе с расширением), куда Вы хотите сохранить файл.");
                    string way = Console.ReadLine();
                    if (File.Exists(way))
                    {

                        if (way.Contains("xml"))
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(Fele));
                            using (FileStream dd = new FileStream(way, FileMode.OpenOrCreate))
                            {
                                xml.Serialize(dd, subject);
                            }
                        }
                        else if (way.Contains("json"))
                        {
                            string json = JsonConvert.SerializeObject(subject);
                            File.WriteAllText(way, json);
                        }
                        else if (put.Contains("txt"))
                        {
                            string text = File.ReadAllText(put);
                            List<Fele> tekst = JsonConvert.DeserializeObject<List<Fele>>(text);
                            Fele vivod;
                            XmlSerializer xml = new XmlSerializer(typeof(Fele));
                            using (FileStream dd = new FileStream(put, FileMode.Open))
                            {
                                vivod = (Fele)xml.Deserialize(dd);
                            }
                        }
                    }
                    else
                    {
                        File.Create(way);
                        if (way.Contains("xml"))
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(Fele));
                            using (FileStream dd = new FileStream(way, FileMode.Create))
                            {
                                xml.Serialize(dd, subject);
                            }
                        }
                        else if (way.Contains("json"))
                        {
                            string json = JsonConvert.SerializeObject(subject);
                            File.WriteAllText(way, json);
                        }
                        else if (way.Contains("txt"))
                        {
                            if (put.Contains("xml"))
                            {
                                Fele vivod;
                                XmlSerializer xml = new XmlSerializer(typeof(Fele));
                                using (FileStream dd = new FileStream(put, FileMode.Open))
                                {
                                    vivod = (Fele)xml.Deserialize(dd);
                                }
                            }
                            else if (put.Contains("json"))
                            {
                                string text = File.ReadAllText(put);
                                List<Fele> tekst = JsonConvert.DeserializeObject<List<Fele>>(text);
                            }
                        }

                    }
                }
                else if (com.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Завершение программы.");
                }
            }
        }
    }
}