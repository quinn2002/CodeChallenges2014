using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection;
using System.Text;

/*
 Week 11
 * 
 Write and design a coupon code that you could use to give a discount on an eCommerce site.  The coupon should have the ability to be associated with the following properties.
- Do not use a DB to store the coupon and it's related meta-data.
- The coupon should have a discount percentage associated with it (ie. 10%, 25%, etc.)
- The coupon should have an expiration date.
- Coupons should be unique (ie. no duplicate coupon codes)
 
Once you have designed how you want to represent your coupon and it's data, write a single method or function that checks to see if the coupon is valid.  If it is return true, otherwise return false.  False would indicate expired coupons, coupons with an invalid code or characters, etc.
 
This challenge is a little more on the design side rather than the programming side but you will need to check your design with code.
 
Send questions and solutions to dan.bunker@stgutah.com.  Thanks
 
Dan
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge11_Coupon : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            var outputString = new StringBuilder();

            // NOTE: altering the sequence number (and consequently the input name attribute) for any ChallengeInput in the database will need to also be updated here
            string couponCode = inputValues["coupon10"] == null ? "" : inputValues["coupon10"].ToString();
            string discountPercent = inputValues["coupon20"] == null ? "" : inputValues["coupon20"].ToString();
            string expirationDate = inputValues["coupon30"] == null ? "" : inputValues["coupon30"].ToString();

            Type couponType = typeof(Coupon);
            var userArgs = new Dictionary<PropertyInfo, string>();
            userArgs.Add(couponType.GetProperty("CouponCode"), couponCode);
            userArgs.Add(couponType.GetProperty("DiscountPercent"), discountPercent);
            userArgs.Add(couponType.GetProperty("ExpirationDate"), expirationDate);

            var coupons = new List<Coupon>();

            // validate user-defined property values
            // if validation passes, dynamically instantiate object and print out results
            // if validation fails, print out property-specific error messages (defined when isValidCoupon() runs) and start over
            if (IsValidCoupon(userArgs, coupons, outputString))
            {
                var coupon = new Coupon();
                foreach (var prop in userArgs.Keys)
                {
                    var propType = Type.GetType(prop.PropertyType.FullName);
                    var propVal = Convert.ChangeType(userArgs[prop], propType); // since all user args are strings, we need to convert them to the property's type
                    coupon.GetType().GetProperty(prop.Name).SetValue(coupon, propVal);
                }
                coupons.Add(coupon);
                outputString.AppendLine("Coupon successfully added:");
                PrintCoupons(coupons, outputString);
            }
            else
            {
                outputString.AppendLine("Please correct above errors by trying again.");
            }
            return outputString.ToString();
        }

        // validate user-provided values for each class property by dynamically invoking each [NameOfProperty]Validator class's Validate() method
        public static bool IsValidCoupon(Dictionary<PropertyInfo, string> userArgs, List<Coupon> coupons, StringBuilder outputString)
        {
            bool isValid = true;
            foreach (var prop in userArgs.Keys)
            {
                string propName = prop.Name;
                var currentNs = typeof(Coupon).Namespace; // TODO - make current namespace dynamic in case Validator classes are ever moved?
                Type propValidatorClass = Type.GetType(currentNs + "." + propName + "Validator");
                string userVal = userArgs[prop];

                if (propValidatorClass != null)
                {
                    IValidator<string> propValidatorObj = Activator.CreateInstance(propValidatorClass) as IValidator<string>;
                    if (!propValidatorObj.Validate(userVal))
                    {
                        outputString.AppendLine(propValidatorObj.ErrorMsg);
                        isValid = false;
                    }
                }
                else
                {
                    outputString.AppendLine(String.Format("Error. No validation found for property: {0}", propName));
                    isValid = false;
                }
            }
            return isValid && !DuplicatePropertyValsExist(userArgs, coupons, outputString);
        }

        // any property with the custom [PropertyMustBeUnique] attribute is checked against the current user-defined value; true is returned if a duplicate is found
        public static bool DuplicatePropertyValsExist(Dictionary<PropertyInfo, string> userArgs, List<Coupon> coupons, StringBuilder outputString)
        {
            bool hasDuplicates = false;

            foreach (var c in coupons)
            {
                foreach (var prop in c.GetType().GetProperties())
                {
                    foreach (var attr in prop.GetCustomAttributes(true))
                    {
                        PropertyMustBeUniqueAttribute propHasUniqueConstraint = attr as PropertyMustBeUniqueAttribute;
                        string propVal = c.GetType().GetProperty(prop.Name).GetValue(c).ToString();
                        if (propHasUniqueConstraint != null && userArgs[prop] == propVal)
                        {
                            hasDuplicates = true;
                            outputString.AppendLine(String.Format("Error. A duplicate value exists for the following property: {0}.  Please provide a unique value.", prop.Name));
                            return hasDuplicates;
                        }
                    }
                }
            }
            return hasDuplicates;
        }

        // string data dump of all current Coupon objects user has successfully created
        public static void PrintCoupons(List<Coupon> coupons, StringBuilder outputString)
        {
            outputString.AppendLine("\n");

            foreach (var prop in typeof(Coupon).GetProperties())
            {
                outputString.Append(prop.Name.PadRight(30));
            }
            outputString.AppendLine();

            foreach (var c in coupons)
            {
                foreach (var prop in c.GetType().GetProperties())
                {
                    string propVal = c.GetType().GetProperty(prop.Name).GetValue(c).ToString();
                    foreach (var attr in prop.GetCustomAttributes(true))
                    {
                        // for certain properties (e.g. dates, percentages) apply any formats defined in the custom [PropertyDisplayFormat()] attribute for the property
                        PropertyDisplayFormatAttribute propDisplayFmt = attr as PropertyDisplayFormatAttribute;
                        if (propDisplayFmt != null)
                        {
                            var propType = Type.GetType(prop.PropertyType.FullName);
                            var propValCasted = Convert.ChangeType(propVal, propType); // for string formatting, we need to convert val from a string to the property's type
                            propVal = String.Format(propDisplayFmt.PropertyDisplayFormat, propValCasted);
                        }
                    }
                    outputString.Append(propVal.PadRight(30));
                }
                outputString.AppendLine();
            }
            outputString.AppendLine();
        }
    }

    public class Coupon
    {
        //properties
        [PropertyMeta("limit 10 alphanumeric characters, no spaces")]
        [PropertyMustBeUnique]
        public string CouponCode { get; set; }

        private decimal discountPercent;

        [PropertyMeta("must be a valid percentage, e.g. 25 or 0.25")]
        [PropertyDisplayFormat("{0:#0.##%}")]
        public decimal DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }
            set
            {
                if (value > 1) // forces values to be a decimal percentage, e.g. 25 becomes 0.25
                {
                    this.discountPercent = value / 100;
                }
                else
                {
                    this.discountPercent = value;
                }
            }
        }

        [PropertyMeta("must be a valid date in the future, M/dd/yyyy format, e.g. 8/12/2020")]
        [PropertyDisplayFormat("{0:M/d/yyyy}")]
        public DateTime ExpirationDate { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyMetaAttribute : System.Attribute
    {
        //properties
        public string PropertyMetaInfo { get; private set; }

        //constructor
        public PropertyMetaAttribute(string propertyMetaInfo)
        {
            this.PropertyMetaInfo = propertyMetaInfo;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyDisplayFormatAttribute : System.Attribute
    {
        //properties
        public string PropertyDisplayFormat { get; private set; }

        //constructor
        public PropertyDisplayFormatAttribute(string displayFmt)
        {
            this.PropertyDisplayFormat = displayFmt;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyMustBeUniqueAttribute : System.Attribute
    { }

    // validation class for each property value must be called [NameOfProperty]Validator, e.g. CouponCodeValidator
    public interface IValidator<T>
    {
        //properties
        string SuccessMsg { get; }
        string ErrorMsg { get; }

        //methods
        bool Validate(T value);
    }

    public class CouponCodeValidator : IValidator<string>
    {
        //properties
        public string SuccessMsg
        {
            get
            {
                return "Coupon Code is valid.";
            }
        }
        public string ErrorMsg
        {
            get
            {
                return "Error validating coupon code.  Ensure coupon code contains no more than 10 alphanumeric characters (no spaces).";
            }
        }

        //methods
        public bool Validate(string couponCode)
        {
            foreach (char c in couponCode)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return couponCode.Length > 0 && couponCode.Length <= 10;
        }
    }

    public class DiscountPercentValidator : IValidator<string>
    {

        //properties
        public string SuccessMsg
        {
            get
            {
                return "Dicount Percentage is valid.";
            }
        }
        public string ErrorMsg
        {
            get
            {
                return "Error validating discount percentage.  Ensure percentage is between 0 and 100.";
            }
        }

        //methods
        public bool Validate(string discountPercent)
        {
            decimal discountPercentNum;
            return Decimal.TryParse(discountPercent, out discountPercentNum)
                && discountPercentNum >= 0
                && discountPercentNum / 100 <= 1;
        }
    }

    public class ExpirationDateValidator : IValidator<string>
    {
        //properties
        public string SuccessMsg
        {
            get
            {
                return "Expiration Date is valid.";
            }
        }
        public string ErrorMsg
        {
            get
            {
                return "Error validating expiration date.  Make sure the date is valid (M/dd/yyyy format) and has NOT passed.";
            }
        }

        //methods
        public bool Validate(string expirationDateStr)
        {
            DateTime expirationDate;
            return DateTime.TryParseExact(expirationDateStr, "M/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out expirationDate)
                && expirationDate > DateTime.Now;
        }
    }
}
