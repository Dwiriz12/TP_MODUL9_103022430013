using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022430013
{
    internal class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string filePath = "covid_config.json";
        public CovidConfig()
        {
        }

        public void Load()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                CovidConfig data = JsonSerializer.Deserialize<CovidConfig>(json);

                if (data != null)
                {
                    satuan_suhu = data.satuan_suhu;
                    batas_hari_deman = data.batas_hari_deman;
                    pesan_ditolak = data.pesan_ditolak;
                    pesan_diterima = data.pesan_diterima;
                }
            }
            else
            {
                satuan_suhu = "celcius";
                batas_hari_deman = 14;
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

                Save();
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }

            Save();
        }
    }
}