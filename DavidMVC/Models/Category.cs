using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DavidMVC.Models
{
    public class Category
    {
        /// <summary>
        /// 产品分类ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string CategoryName { get; set; }
    }

    public static class CategoryProvider
    {
        /// <summary>
        /// 产品总分类
        /// </summary>
        public static readonly List<Category> AllCategories = new List<Category>()
        { 
            new Category(){ CategoryId="001", CategoryName="Nokia"},
            new Category(){ CategoryId="002", CategoryName="iPhone"},
            new Category(){ CategoryId="003", CategoryName="Anycall"}
        };
    }
}