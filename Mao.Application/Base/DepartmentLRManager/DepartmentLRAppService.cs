using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using Mao.Application;
using Mao.Core.Base;
using Mao.Extensions;
using Mao.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Mao.Application.Base.DepartmentManager
{
    /// <summary>
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentLRAppService : MaoAppServiceBase, IDepartmentLRAppService
    {



        private IRepository<Department> _department;
        private readonly ISqlExecuter _sqlExecuter;
        private IRepository<Organize> _organize;

        public DepartmentLRAppService(
             IRepository<Department> department,
            IRepository<Organize> organize
            )
        {

            _department = department;
            _organize = organize;

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public List<Department> GetList()
        {
          return  _department.GetAll().OrderByDescending(t => t.CreationTime).ToList();
        }
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Department GetEntity(string DepartmentId)
        {
            return _department.FirstOrDefault(a => a.DepartmentId == DepartmentId);
        }
        #endregion


        #region 获取数据
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [DontWrapResult]
        public object GetTreeJson(string organizeId, string keyword)
        {
            var data = _department.GetAll().Where(a=>a.OrganizeId==organizeId).ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.FullName.Contains(keyword), "DepartmentId");
            }
            var treeList = new List<TreeEntity>();
            foreach (Department item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.DepartmentId) == 0 ? false : true;
                tree.id = item.DepartmentId;
                tree.text = item.FullName;
                tree.value = item.DepartmentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                treeList.Add(tree);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject(treeList.TreeToJson());
        }
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门树形Json</returns>
        [DontWrapResult]
        public object GetOrganizeTreeJson(string keyword)
        {
            var organizedata =  _organize.GetAll();
            var departmentdata = _department.GetAll();
            var treeList = new List<TreeEntity>();
            foreach (Organize item in organizedata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                if (hasChildren == false)
                {
                    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize";
                treeList.Add(tree);
                #endregion
            }
            foreach (Department item in departmentdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                bool hasChildren = departmentdata.Count(t => t.ParentId == item.DepartmentId) == 0 ? false : true;
                tree.id = item.DepartmentId;
                tree.text = item.FullName;
                tree.value = item.DepartmentId;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "parentId");
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject(treeList.TreeToJson());
        }
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [DontWrapResult]
        public object GetTreeListJson(string condition, string keyword)
        {
            var organizedata = _organize.GetAll().ToList();
            var departmentdata = _department.GetAll().ToList();
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询
                switch (condition)
                {
                    case "FullName":    //部门名称
                        departmentdata = departmentdata.TreeWhere(t => t.FullName.Contains(keyword), "DepartmentId");
                        break;
                    case "EnCode":      //部门编号
                        departmentdata = departmentdata.TreeWhere(t => t.EnCode.Contains(keyword), "DepartmentId");
                        break;
                    case "ShortName":   //部门简称
                        departmentdata = departmentdata.TreeWhere(t => t.ShortName.Contains(keyword), "DepartmentId");
                        break;
                    case "Manager":     //负责人
                        departmentdata = departmentdata.TreeWhere(t => t.Manager.Contains(keyword), "DepartmentId");
                        break;
                    case "OuterPhone":  //电话号
                        departmentdata = departmentdata.TreeWhere(t => t.OuterPhone.Contains(keyword), "DepartmentId");
                        break;
                    case "InnerPhone":  //分机号
                        departmentdata = departmentdata.TreeWhere(t => t.Manager.Contains(keyword), "DepartmentId");
                        break;
                    default:
                        break;
                }
                #endregion
            }
            var treeList = new List<TreeGridEntity>();
            foreach (Organize item in organizedata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                if (hasChildren == false)
                {
                    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.OrganizeId;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.expanded = true;
                item.EnCode = ""; item.ShortName = ""; item.Nature = ""; item.Manager = ""; item.OuterPhone = ""; item.InnerPhone = ""; item.Description = "";
                string itemJson = item.ToJson();
                itemJson = itemJson.Insert(1, "\"DepartmentId\":\"" + item.OrganizeId + "\",");
                itemJson = itemJson.Insert(1, "\"Sort\":\"Organize\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            foreach (Department item in departmentdata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.DepartmentId) == 0 ? false : true;
                tree.id = item.DepartmentId;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.expanded = true;
                tree.hasChildren = hasChildren;
                string itemJson = item.ToJson();
                itemJson = itemJson.Insert(1, "\"Sort\":\"Department\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject(treeList.TreeJson());
        }
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        public object GetFormJson(string keyValue)
        {
            var data = GetEntity(keyValue);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }

        #endregion

    }
}
