﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _dateTimeNowProvider;

        public DateInFutureAttribute() : this(()=> DateTime.Now) { }
        
        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "Date must be from the future";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if(value is DateTime dateTime)
            {
                isValid = dateTime > _dateTimeNowProvider();
            }
            return isValid;
        }
    }
}
