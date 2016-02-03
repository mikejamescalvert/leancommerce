using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Setup
{
    public class DbSetupViewModel : IValidatableObject  
    {
        const string DefaultDB = "leancommerce";
        const string DefaultURL = "mongodb://<<server>>";
        public DbSetupViewModel() : base()
        {
            this.MongoDatabaseName = DefaultDB;
            this.MongoURL = DefaultURL;
        }
        private string _MongoURL;
        [Required]
        [Display(Name="URL")]
        
        public string MongoURL
        {
            get { return _MongoURL; }
            set
            {
                _MongoURL = value;
            }
        }
        private string _MongoDatabaseName;
        [Required]
        [Display(Name = "Database Name")]
        public string MongoDatabaseName
        {
            get { return _MongoDatabaseName; }
            set
            {
                _MongoDatabaseName = value;
            }
        }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (MongoURL == DefaultURL)
                yield return new ValidationResult("Please provide a URL that points to your server.");
        }
    }
}
