using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace PumpStationBase.Domain
{
    public abstract class EntityBase : IDataErrorInfo
    {

        public string this[string property]
        {
            get
            {
                PropertyInfo propertyInfo = this.GetType().GetProperty(property);
                var results = new List<ValidationResult>();

                var result = Validator.TryValidateProperty(
                                          propertyInfo.GetValue(this, null),
                                          new ValidationContext(this, null, null)
                                          {
                                              MemberName = property
                                          },
                                          results);

                if (!result)
                {
                    var validationResult = results.First();
                    return validationResult.ErrorMessage;
                }

                return string.Empty;
            }
        }
        public string Error
        {
            get { return null; }
        }

    }
}
