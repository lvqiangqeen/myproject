using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Domain
{
    public class AIYunNetContext : DbContext
    {
        public AIYunNetContext()
            : base("name=ConnectionString")
        {
            Database.SetInitializer<AIYunNetContext>(null);
        }
        public virtual DbSet<SysAdminUser> SysAdminUser { get; set; }
        public virtual DbSet<WebCompany> WebCompany { get; set; }
        public virtual DbSet<WebPeople> WebPeople { get; set; }
        public virtual DbSet<WebLookup> WebLookUp { get; set; }
        public virtual DbSet<WebCase> WebCase { get; set; }
        public virtual DbSet<WebCaseRelationship> WebCaseRelationship { get; set; }
        public virtual DbSet<WebNews> WebNews { get; set; }
        public virtual DbSet<WebFriendLink> WebFriendLink { get; set; }
        public virtual DbSet<WebMenu> WebMenu { get; set; }
        public virtual DbSet<WebImg> WebImg { get; set; }
        public virtual DbSet<WebFile> WebFile { get; set; }
        public virtual DbSet<WebRecommend> WebRecommend { get; set; }
        public virtual DbSet<WebGoods> WebGoods { get; set; }
        public virtual DbSet<WebPicture> WebPicture { get; set; }
        public virtual DbSet<WebUser> WebUser { get; set; }
        public virtual DbSet<WebPeopleAuthentication> WebPeopleAuthentication { get; set; }
        public virtual DbSet<WebPeopleGuarantMoney> WebPeopleGuarantMoney { get; set; }
        public virtual DbSet<WebCompanyUser> WebCompanyUser { get; set; }
        public virtual DbSet<WebCompanyAuthentication> WebCompanyAuthentication { get; set; }
        public virtual DbSet<WebCompanyGuarantMoney> WebCompanyGuarantMoney { get; set; }
        public virtual DbSet<PeopleJian> PeopleJian { get; set; }
        public virtual DbSet<Z_Comment> Z_Comment { get; set; }
        public virtual DbSet<Z_replyComment> Z_replyComment { get; set; }
        public virtual DbSet<t_rms_region> t_rms_region { get; set; }
        public virtual DbSet<t_Province> t_Province { get; set; }
        public virtual DbSet<t_Area> Areas { get; set; }
        public virtual DbSet<t_City> t_City { get; set; }
        public virtual DbSet<WebWorker> WebWorker { get; set; }
        public virtual DbSet<WebBuiding> WebBuiding { get; set; }
        public virtual DbSet<WebBuidingStages> WebBuidingStages { get; set; }
        public virtual DbSet<WebBuidingSingle> WebBuidingSingle { get; set; }
        public virtual DbSet<DownLoad> DownLoad { get; set; }
        public virtual DbSet<DownLoadType> DownLoadType { get; set; }
        public virtual DbSet<All_Nav> All_Nav { get; set; }
        public virtual DbSet<DecDemand> DecDemand { get; set; }
        public virtual DbSet<WebCaseImg> WebCaseImg { get; set; }
        public virtual DbSet<DecDemandAccept> DecDemandAccept { get; set; }
        public virtual DbSet<WebBuidingCaseComment> WebBuidingCaseComment { get; set; }
        public virtual DbSet<WebBuidTogether> WebBuidTogether { get; set; }
        public virtual DbSet<WebBuidingContract> WebBuidingContract { get; set; }
    }
}
