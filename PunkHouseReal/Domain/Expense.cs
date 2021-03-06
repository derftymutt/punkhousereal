﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PunkHouseReal.Models.EnumsAndConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Domain
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ExpenseType ExpenseType { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public bool IsDividedUnevenly { get; set; }
        [NotMapped]
        public Dictionary<string, decimal> UnevenTotals { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }

        public int HouseId { get; set; }
        public House House { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public HouseMate HouseMate { get; set; }

        public ICollection<HouseMateExpense> HouseMateExpenses { get; set; }

        //TODO: IsRecurring bool, int RecurPeriod (in days, months?)

        public Expense()
        {
            DateCreated = DateTimeOffset.Now;
            DateModified = DateTimeOffset.Now;
            IsPaid = false;
            IsDividedUnevenly = true;

        }
    }
}
