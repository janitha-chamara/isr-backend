using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrations.DataModels
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        public string UUID { get; set; }
        public string? JobNo { get; set; }
        public string? JobName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? ClientName { get; set; }
        public DateTime? WFMLastUpdate { get; set; }
        public string? ProjectManger { get; set; }
        public string? SDM { get; set; }
        public decimal? QuotedHours { get; set; }
        public decimal? ActualHours { get; set; }

        //added project status
        public string? ProjectStatus { get; set; }
        public decimal? CurrentQuotedHoursUsed { get; set; }
        public decimal? EstToComplHours { get; set; }
        public decimal? TotalForeCastHours { get; set; }
        public decimal? CurrentthroughProject { get; set; }
        public decimal? ForecastQuotedHours { get; set; }
        public bool? IsLock { get; set; }




        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Response {
    
    private string statusField;
    
    private ResponseCustomField[] customFieldsField;
    
    private string apimethodField;
    
    /// <remarks/>
    public string Status {
        get {
            return this.statusField;
        }
        set {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("CustomField", IsNullable=false)]
    public ResponseCustomField[] CustomFields {
        get {
            return this.customFieldsField;
        }
        set {
            this.customFieldsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("api-method")]
    public string apimethod {
        get {
            return this.apimethodField;
        }
        set {
            this.apimethodField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResponseCustomField {
    
    private uint idField;
    
    private string uUIDField;
    
    private string nameField;
    
    private bool booleanField;
    
    private bool booleanFieldSpecified;
    
    private string textField;
    
    /// <remarks/>
    public uint ID {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    public string UUID {
        get {
            return this.uUIDField;
        }
        set {
            this.uUIDField = value;
        }
    }
    
    /// <remarks/>
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public bool Boolean {
        get {
            return this.booleanField;
        }
        set {
            this.booleanField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool BooleanSpecified {
        get {
            return this.booleanFieldSpecified;
        }
        set {
            this.booleanFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string Text {
        get {
            return this.textField;
        }
        set {
            this.textField = value;
        }
    }
}



    }
}
