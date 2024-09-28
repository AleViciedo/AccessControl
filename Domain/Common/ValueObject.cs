﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Common
{
    abstract public class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;
            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
    }
}
