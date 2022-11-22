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
                        if (way.Contains("xml"))
                        {
                            if (put.Contains("txt"))
                            {
                            SerializeriDeserializer.SerializeXML(subject, way);
                            }
                            else
                            {
                            SerializeriDeserializer.ЖысонДириализе(put);
                            SerializeriDeserializer.SerializeXML(subject, way);
                            }
                        }
                        else if (way.Contains("json"))
                        {
                            if (put.Contains("txt"))
                            {
                            SerializeriDeserializer.SerialJson(subject, way);
                            }
                            else
                            {
                            SerializeriDeserializer.Deserialize(way);
                            SerializeriDeserializer.SerialJson(subject, way);
                            }
                        }
                        else if (way.Contains("txt"))
                        {
                            if (put.Contains("xml"))
                            {
                            SerializeriDeserializer.Deserialize(way);
                            }
                            else if (put.Contains("json"))
                            {
                            SerializeriDeserializer.ЖысонДириализе(put);
                            }
                        }
                }
                else if (com.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine(" Завершение программы.");
                }
                }
            }
        }
    }