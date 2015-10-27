using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.DataValidation
{
    public class Validation : IValidation
    {
        public  Dictionary<string, List<string>> Errors { get; private set; }

        public Validation()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public bool IsValid()
        {
            // if Errors is empty return true
            if (Errors.Count == 0)
                return true;
            // Errors does contain errors
            return false;
        }

        public void AddError(string Key, string Error)
        {
            if (Errors.ContainsKey(Key))
            {
                Errors[Key].Add(Error);
            }else
            {
                Errors.Add(Key, new List<String>(){Error});
            }
        }
    }

    public interface IValidation
    {
        bool IsValid();
        void AddError(string Key, string Error);
    }
}
