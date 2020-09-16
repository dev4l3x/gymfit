using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Validations
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.Interfaces;

    public abstract class ValidationRule<TValue>
    {
        public string ErrorText { get; set; }
        public abstract bool Validate(TValue value);
    }

    public class NotNullAndNotEmpty : ValidationRule<string>
    {
        public NotNullAndNotEmpty()
        {
            ErrorText = "No puede estar vacío";
        }
        public override bool Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }


    public class EqualTo<TValue> : ValidationRule<TValue>
    {
        private TValue valueToCompare;
        public EqualTo(TValue value)
        {
            ErrorText = "Las contraseñas no coinciden";
            valueToCompare = value;
        }
        public override bool Validate(TValue value)
        {
            if (valueToCompare != null)
            {
                return valueToCompare.Equals(value);
            }

            return false;
        }
    }

    public class NotGreaterThanToday : ValidationRule<DateTime>
    {
        public NotGreaterThanToday()
        {
            ErrorText = "La fecha no puede ser más reciente a hoy";
        }
        public override bool Validate(DateTime value)
        {
            return value < DateTime.Today;
        }
    }

    public class HasEmailFormat : ValidationRule<string>
    {
        Regex rx = new Regex(".+@.+");

        public HasEmailFormat()
        {
            ErrorText = "El email no tiene el formato correcto";
        }

        public override bool Validate(string value)
        {
            return (value != null && rx.IsMatch(value));
        }

        
    }


    public class IsDoubleFormat : ValidationRule<string>
    {
        public IsDoubleFormat()
        {
            ErrorText = "Tiene que tener un formato númerico";
        }
        public override bool Validate(string value)
        {
            return double.TryParse(value, out _);
        }
    }

    public class IsIntegerFormat : ValidationRule<string>
    {
        public override bool Validate(string value)
        {
            return int.TryParse(value, out _);
        }
    }

    public class IsBetweenValues : ValidationRule<string>
    {
        private int minValue, maxValue;
        private string controlName;

        

        public IsBetweenValues(int minValue, int maxValue, string controlName = "")
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            ErrorText = $"{controlName} tiene que estar entre {minValue} y {maxValue}";
        }
        public override bool Validate(string value)
        {
            if (minValue < maxValue && int.TryParse(value, out var number))
            {
                return number >= minValue && number <= maxValue;
            }

            return false;
        }
    }


    public class ValidatableObject<TValue>
    {
        public TValue Value { get; set; }
        public List<string> ErrorMessages { get; set; }
        public List<ValidationRule<TValue>> ValidationRules { get; set; }

        public ValidatableObject()
        {
            ErrorMessages = new List<string>();
            ValidationRules = new List<ValidationRule<TValue>>();
        }

        public bool Validate()
        {
            ErrorMessages.Clear();
            foreach (var validationRule in ValidationRules)
            {
                if (!validationRule.Validate(Value))
                {
                    ErrorMessages.Add(validationRule.ErrorText);
                    return false;
                }
            }

            return true;
        }

        public string ErrorMessagesAsString()
        {
            return string.Join(Environment.NewLine, ErrorMessages);
        }

    }
}
