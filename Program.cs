using System;

namespace TP_MODUL9_103022430013
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();

            config.Load();

            config.UbahSatuan();

            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;

            if (config.satuan_suhu == "celcius")
            {
                suhuValid = (suhu >= 36.5 && suhu <= 37.5);
            }
            else
            {
                suhuValid = (suhu >= 97.7 && suhu <= 99.5);
            }

            if (suhuValid && hari < config.batas_hari_deman)
            {
                Console.WriteLine(config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.pesan_ditolak);
            }
        }
    }
}