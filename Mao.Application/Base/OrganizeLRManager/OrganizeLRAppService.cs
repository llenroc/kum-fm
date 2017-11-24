using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using Mao.Application;
using Mao.Core.Base;
using Mao.Extensions;
using Mao.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mao.Application.Base.OrganizeManager
{
    /// <summary>
    /// 描 述：机构管理
    /// </summary>
    public class OrganizeLRAppService : MaoAppServiceBase, IOrganizeLRAppService
    {
        private IRepository<Organize> _organize;
        private readonly ISqlExecuter _sqlExecuter;

        public OrganizeLRAppService(
             IRepository<Organize> organize

            )
        {

            _organize = organize;

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public List<Organize> GetList()
        {
            var res = _organize.GetAll().OrderByDescending(t => t.SortCode).ToList();
            return res;
        }
        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Organize GetEntity(string OrganizeId)
        {
            var res = _organize.FirstOrDefault(a => a.OrganizeId == OrganizeId);
            return res;
        }
        #endregion




        #region 获取数据
        /// <summary>
        /// 机构列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        public string GetTreeJson(string keyword)
        {
            var data = _organize.GetAll().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.FullName.Contains(keyword), "OrganizeId");
            }
            var treeList = new List<TreeEntity>();
            foreach (Organize item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                treeList.Add(tree);
            }
            return treeList.TreeToJson();
        }


        /// <summary>
        /// 机构列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [DontWrapResult]
        public object GetTreeListJson(string condition, string keyword)
        {
            var data = _organize.GetAll().ToList();
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询
                switch (condition)
                {
                    case "FullName":    //公司名称
                        data = data.TreeWhere(t => t.FullName.Contains(keyword), "OrganizeId");
                        break;
                    case "EnCode":      //外文名称
                        data = data.TreeWhere(t => t.EnCode.Contains(keyword), "OrganizeId");
                        break;
                    case "ShortName":   //中文名称
                        data = data.TreeWhere(t => t.ShortName.Contains(keyword), "OrganizeId");
                        break;
                    case "Manager":     //负责人
                        data = data.TreeWhere(t => t.Manager.Contains(keyword), "OrganizeId");
                        break;
                    default:
                        break;
                }
                #endregion
            }
            var treeList = new List<TreeGridEntity>();
            foreach (Organize item in data)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                tree.id = item.OrganizeId;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.expanded = true;
                tree.entityJson = item.ToJson();
                treeList.Add(tree);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject(treeList.TreeJson());
        }
        /// <summary>
        /// 机构实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        public string GetFormJson(string keyValue)
        {
            var data = GetEntity(keyValue);
            return data.ToJson();
        }
        #endregion




        

        #region 提交数据
        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        /// 

        public void RemoveForm(string keyValue)
        {
            _organize.Delete(a => a.OrganizeId == keyValue);
        }
        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public object SaveForm(Organize organize)
        {
            if (!string.IsNullOrEmpty(organize.OrganizeId))
            {
                return _organize.Update(organize);
            }
            else
            {
                organize.OrganizeId = new Guid().ToString();
                return _organize.Insert(organize);
            }
        }
        #endregion
    }
}
