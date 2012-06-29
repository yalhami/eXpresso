using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.ExpressCMS.DataLayer.Enums
{
    public class RootEnums
    {
        public enum AccountType
        {
            Companies = 1, Individuals = 2, ProxyTrustee = 3, JointAccount = 4, EmployeeHavingRelation = 5
        }
        public enum CategoryType
        {
            News = 1, Menu = 2, Marquee = 3, Gallery = 4, Event = 5, Fatawa = 6, IslamicStudies = 7, Sawtyyat = 8, Videos = 9, Banner = 10, AlRamzVideos = 11, Projects = 99, ECommerce = 12
        }
        public enum NewsItemURLType
        {
            Internal = 1, External = 2
        }
        public enum MenuItemURLtype
        {
            Internal = 1, External = 2
        }
        public enum MarqueeItemURLType
        {
            Internal = 1, External = 2, TextOnly = 3
        }
        public enum UserType
        {
            SuperAdmin = 1,
            NormalUser = 2
        }
        public enum ContactStatus
        {
            Active = 1, InActive = 2
        }
        public enum ObjectType
        {
            News = 1,
            Menu = 2,
            Contact = 3,
            Email = 4,
            Html = 5,
            Marquee = 6,
            Comment = 7
        }
        public enum SendingStatus
        {
            Pending = 1, Sent = 2, Delivered = 3, failed = 4
        }
        public enum DeliveryStatus
        {
            Delivered = 1, Failed = 2, Unknown = 3
        }
        public enum CommentStatus
        {
            Pending = 1, Reviewed = 2
        }
        public enum CommentType
        {
            Comment = 1
        }
        public enum InQuiryStatus
        {
            Pending = 1, Reviewed = 2
        }
        public enum PageType
        {
            System = 1, User = 2
        }
        public enum HtmlBlockType : int
        {
            Careers = 2, HTML = 1
        }
        public enum HtmlBlockStatus
        {
            Visible = 1, Expired = 2
        }
        public enum BannerStatus
        {
            Active = 0, InActive = 1
        }
        public enum BannerType
        {
            ViewsBased = 0, ClicksBased = 1, StaticBased = 2
        }
        public enum UrlType
        {
            External = 0, Internal = 1
        }
        public enum GalleryType
        {
            Image = 1, Document = 2, Video = 3
        }
        public enum ForumUserType : int
        { Normal = 1, Extra = 2 }
        public enum ForumUserTrusted : int
        { NotTrusted = 0, Trusted = 1 }
        public enum ForumUserBanned : int
        { NotBanned = 0, Banned = 1 }
        public enum ForumThreadStatus : int
        { Active = 1, InActive }
        public enum ForumPostStatus : int
        { Active = 1, InActive }
        public enum UserRoles : int
        { AddThread = 36 }
        public enum AudioVideoType : int
        {
            Audio = 0, Video = 1, Both = -1
        }
        public enum FatawaStatus : int
        {
            Resolved = 1, Pending = 0
        }
        public enum EventRepeatType : int
        {
            DoNotRepeat = 1,
            Daily = 2,
            Weekly = 3,
            Monthly = 4,
            Yearly = 5
        }
        public enum EventMonthlyType : int
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Last = 5
        }
        public enum EmailType : int
        {
            System = 1, Normal = 2
        }
    }
}
