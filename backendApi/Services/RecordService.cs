using BackendApi.Models;
using System.Collections.Generic;
using BackendApi.Data;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackendApi.Services
{
    public class RecordService : IRecordsService
    {
        public IEnumerable<Record> GetAll()
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    return context.Records.ToList();
                }
            }
            catch 
            {

                return null;
            }
           
        }

        public Record Save(Record record)
        {

            try
            {
                using (var context = new RecordsContext())
                {
                    context.Records.Add(record);
                    context.SaveChanges();
                    return record;
                }
            }
            catch 
            {
                return null;
            }
        }

        public Record Update(int id, Record record)
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    var oldRecord = context.Records.FirstOrDefault(n => n.Id == id);
                    if (oldRecord == null) return null;
                    //oldRecord.Id = record.Id;
                    oldRecord.Day = record.Day;
                    oldRecord.StrId = record.StrId;
                    oldRecord.RecordDate = record.RecordDate;
                    oldRecord.Teacher = record.Teacher;
                    oldRecord.Topic = record.Topic;
                    oldRecord.Type = record.Type;
                    oldRecord.Minuets = record.Minuets;
                    oldRecord.Segment = record.Segment;

                    context.SaveChanges();

                    return record;
                }
            }
            catch
            {

                return null;
            }
            
        }
    }
}
