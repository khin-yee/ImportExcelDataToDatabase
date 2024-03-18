using CsvHelper;
using CsvHelper.Configuration;
using Excel_PostgreDB.Domain.IRepository;
using Excel_PostgreDB.Domain.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseConnect _connect;
        public Repository(DatabaseConnect connection)
        {
            _connect = connection;
        }

        public Task<object> ImportCSVData()
        {
            throw new NotImplementedException();
        }

        public async Task<object> ImportExcelData()
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
            };
            using (var reader = new StreamReader(@"C:\C# Project\Excel_PostgreDB\Excel_PostgreDB.Domain\CSVfile\SR.csv"))
            using (var csv = new CsvReader(reader, config))
            {

                var records = csv.GetRecords<SR>().Select((item, Index) => new SR
                {              
                    SRPcode = item.SRPcode,
                    SRNameEng = item.SRNameEng,
                    SRNameMMR = item.SRNameMMR
                }).ToList();

                //var srList = new List<SR>();
                //foreach (var item in csv.GetRecords<SR>().ToList())
                //{
                //    var record2 = new SR
                //    {
                //        SRPcode = item.SRPcode,
                //        SRNameEng = item.SRNameEng,
                //        SRNameMMR = item.SRNameMMR
                //    };

                //    srList.Add(record2);
                //}

                records.ForEach(item => _connect.SR.Add(item));

                _connect.SaveChanges();             
            }

            using (StreamReader reader = new StreamReader(@"C:\C# Project\Excel_PostgreDB\Excel_PostgreDB.Domain\CSVfile\District.csv"))
           
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<District>().Select((item, Index) => new District
                {
                    SR = item.SR,
                    SRNameEng = item.SRNameEng,
                    DistrictNameEng = item.DistrictNameEng,
                    DistrictPcode = item.DistrictPcode,
                    DistrictNameMMR = item.DistrictNameMMR,
                                    
                }).ToList();
                records.ForEach(item => _connect.District.Add(item));
                _connect.SaveChanges(true);
            }

            using (StreamReader reader = new StreamReader(@"C:\C# Project\Excel_PostgreDB\Excel_PostgreDB.Domain\CSVfile\Township.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Township>().Select((item, Index) => new Township
                {
                    SRPcode = item.SRPcode,
                    SRNameEng = item.SRNameEng,
                    DistrictNameEng = item.DistrictNameEng,
                    DistrictPcode = item.DistrictPcode,
                    TownshipNameEng = item.TownshipNameEng,
                    TownshipNameMMR = item.TownshipNameMMR,
                    TspPcode = item.TspPcode,

                }).ToList();
                
                records.ForEach(item => _connect.Township.Add(item));
                _connect.SaveChanges();
                
            }
            using (StreamReader reader = new StreamReader(@"C:\C# Project\Excel_PostgreDB\Excel_PostgreDB.Domain\CSVfile\Town.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Town>().Select((item, Index) => new Town
                {
                    SRPcode = item.SRPcode,
                    SRNameEng = item.SRNameEng,
                    DistrictPcode = item.DistrictPcode,
                    DistrictNameEng = item.DistrictNameEng,
                    TspPcode = item.TspPcode,
                    TownshipNameEng = item.TownshipNameEng,
                    TownPcode = item.TownPcode,
                    TownNameEng = item.TownNameEng,
                    TownNameMMR = item.TownNameMMR
           
                }).ToList();

                records.ForEach(item => _connect.Town.Add(item));
                _connect.SaveChanges();
            }

            using (StreamReader reader = new StreamReader(@"C:\C# Project\Excel_PostgreDB\Excel_PostgreDB.Domain\CSVfile\Ward.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Ward>().Select((item, Index) => new Ward
                {
                    SRPcode = item.SRPcode,
                    SRNameEng = item.SRNameEng,
                    TspPcode = item.TspPcode,
                    TownshipNameEng = item.TownshipNameEng,
                    Town = item.Town,
                    TownPcode = item.TownPcode,
                    DistrictNameEng = item.DistrictNameEng,
                    DistrictPcode = item.DistrictPcode,
                    WardPcode = item.WardPcode,
                    WardNameEng = item.WardNameEng,
                    WardNameMMR = item.WardNameMMR

                }).ToList();          
                records.ForEach(item => _connect.Ward.Add(item));
                _connect.SaveChanges();
                return records;

            }
        }
    }
}
