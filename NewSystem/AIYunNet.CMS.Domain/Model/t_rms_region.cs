using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("t_rms_region")]
    public class t_rms_region
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        [Column("FullName")]
        public string FullName { get; set; }
        /// <summary>
        /// RegionLevel
        /// </summary>
        [Column("RegionLevel")]
        public int RegionLevel { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>
        [Column("ParentId")]
        public int ParentId { get; set; }
        /// <summary>
        /// RegionCode
        /// </summary>
        [Column("RegionCode")]
        public string RegionCode { get; set; }
        /// <summary>
        /// ParentRegionCode
        /// </summary>
        [Column("ParentRegionCode")]
        public string ParentRegionCode { get; set; }
        /// <summary>
        /// IsMunicipalityCity
        /// </summary>
        [Column("IsMunicipalityCity")]
        public string IsMunicipalityCity { get; set; }
        /// <summary>
        /// Suffix
        /// </summary>
        [Column("Suffix")]
        public string Suffix { get; set; }
        /// <summary>
        /// LocationX
        /// </summary>
        [Column("LocationX")]
        public decimal LocationX { get; set; }
        /// <summary>
        /// LocationY
        /// </summary>
        [Column("LocationY")]
        public decimal LocationY { get; set; }
        /// <summary>
        /// CreateOn
        /// </summary>
        [Column("CreateOn")]
        public string CreateOn { get; set; }
        /// <summary>
        /// UpdateOn
        /// </summary>
        [Column("UpdateOn")]
        public string UpdateOn { get; set; }
    }
}
