using Model;
using Newtonsoft.Json;
using NTDCommon;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBService
{
    public class NmfsTaskService
    {
        private static readonly nmfs_taskManager EntityMgr = new nmfs_taskManager();

        /// <summary>
        /// 得到实体类转成Dic
        /// </summary>
        private static Dictionary<string, object> EntityMap = ToMap(new nmfs_task());

        /// <summary>
        /// 实体类转成Dic方法
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static Dictionary<string, object> ToMap(object o)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            Type t = o.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();
                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new object[] { }));
                }
            }
            return map;
        }
        /// <summary>
        /// 根据主键获取一条数据信息，失败返回null
        /// </summary>
        /// <returns></returns>
        public static nmfs_task GetOneDataByPrimaryKey(object o)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_task>()
                    .InSingle(o);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 获取全部信息
        /// </summary>
        /// <returns></returns>
        public static List<nmfs_task> GetDataByNumber(int maxUpDataCount)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_task>()
                  .Take(maxUpDataCount)
                   .OrderBy(it => it.task_level, OrderByType.Desc)
                  .OrderBy(it => it.create_time, OrderByType.Desc)
                  .ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 获取全部信息
        /// </summary>
        /// <returns></returns>
        public static List<nmfs_task> GetData()
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_task>()
                  .OrderBy(it => it.task_level, OrderByType.Desc)
                    .OrderBy(it => it.create_time, OrderByType.Desc)
                  .ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 根据实体类获取全部信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<nmfs_task> GetDataByEntity(nmfs_task entity)
        {
            try
            {
                return GetDataByDic(ToMap(entity));
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 查询显示
        /// </summary>
        /// <param name="getQueryParameter"></param>
        /// <returns></returns>
        public static List<nmfs_task> GetDataByDic(Dictionary<string, object> queryValue, ConditionalType conditionalType = ConditionalType.Equal)
        {
            try
            {
                List<IConditionalModel> conModels = new List<IConditionalModel>();
                foreach (var item in queryValue)
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value == null ? "" : item.Value.ToString())) continue;
                    if (!EntityMap.ContainsKey(item.Key)) continue;
                    conModels.Add(new ConditionalModel() { FieldName = item.Key, ConditionalType = conditionalType, FieldValue = item.Value.ToString() });
                }

                var res = EntityMgr.Db.Queryable<nmfs_task>().Where(conModels)
                  .WhereIF(queryValue.ContainsKey("startTime") && queryValue.ContainsKey("endTime"), it => SqlFunc.Between(it.create_time, queryValue["startTime"], queryValue["endTime"]))
                   .OrderBy(it => it.task_level, OrderByType.Desc)
                  .OrderBy(it => it.create_time, OrderByType.Desc)
                  .ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }


        /// <summary>
        /// 根据实体类分页查询
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<nmfs_task> GetPageDataByEntity(int currentPageIndex, int pageSize, ref int totalCount, nmfs_task entity)
        {
            try
            {
                return GetPageDataByDic(currentPageIndex, pageSize, ref totalCount, ToMap(entity), ConditionalType.Equal);
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }
        /// <summary>
        /// 根据dic分页查询
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="queryValue"></param>
        /// <param name="conditionalType"></param>
        /// <returns></returns>
        public static List<nmfs_task> GetPageDataByDic(int currentPageIndex, int pageSize, ref int totalCount, Dictionary<string, object> queryValue, ConditionalType conditionalType = ConditionalType.Equal)
        {
            try
            {
                List<IConditionalModel> conModels = new List<IConditionalModel>();
                foreach (var item in queryValue)
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value == null ? "" : item.Value.ToString())) continue;
                    if (!EntityMap.ContainsKey(item.Key)) continue;
                    conModels.Add(new ConditionalModel() { FieldName = item.Key, ConditionalType = conditionalType, FieldValue = item.Value.ToString() });
                }

                var res = EntityMgr.Db.Queryable<nmfs_task>().Where(conModels)
                  .WhereIF(queryValue.ContainsKey("startTime") && queryValue.ContainsKey("endTime"), it => SqlFunc.Between(it.create_time, queryValue["startTime"], queryValue["endTime"]))
                  .OrderBy(it => it.task_level, OrderByType.Desc)
                  .OrderBy(it => it.create_time, OrderByType.Desc)
                  .ToPageList(currentPageIndex, pageSize, ref totalCount);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Insert(nmfs_task entity)
        {
            try
            {
                if (entity.create_time == null) entity.create_time = DateTime.Now;
                if (entity.update_time == null) entity.update_time = DateTime.Now;

                if (string.IsNullOrEmpty(entity.id)) entity.id = System.Guid.NewGuid().ToString("N");
                var res = EntityMgr.Db.Insertable(entity)
                .Where(true/* Is no insert null */, false/*off identity*/)
                .ExecuteCommandIdentityIntoEntity();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public static bool InsertByList(List<nmfs_task> entityList)
        {
            try
            {
                if (entityList == null || entityList.Count <= 0) return false;
                foreach (var entity in entityList)
                {
                    if (entity.create_time == null) entity.create_time = DateTime.Now;
                    if (entity.update_time == null) entity.update_time = DateTime.Now;

                    if (string.IsNullOrEmpty(entity.id)) entity.id = System.Guid.NewGuid().ToString("N");
                }

                var rst = EntityMgr.Db.Insertable(entityList.ToArray())
                // .Where(true/* Is no insert null */, false/*off identity*/)
                .ExecuteCommand();
                return rst > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        public static bool Save(nmfs_task entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.id))
                {
                    return Insert(entity);
                }
                else
                {
                    return Update(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Update(nmfs_task entity)
        {
            try
            {
                entity.update_time = DateTime.Now;
                var res = EntityMgr.Db.Updateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();
                return res > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool DeletePrimaryKey(object primaryKeyValue)
        {
            try
            {
                var res = EntityMgr.Db.Deleteable<nmfs_task>().In(primaryKeyValue).ExecuteCommand();
                return res > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }

        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static bool DeletePrimaryKey(object[] primaryKeyValueArray)
        {
            try
            {
                var res = EntityMgr.Db.Deleteable<nmfs_task>().In(primaryKeyValueArray).ExecuteCommand();
                return res > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 实体类条件删除
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static bool DeleteByEntity(nmfs_task entity)
        {
            try
            {
                return DeleteByDic(ToMap(entity));
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 根据dic删除
        /// </summary>
        /// <param name="queryValue"></param>
        /// <returns></returns>
        public static bool DeleteByDic(Dictionary<string, object> queryValue)
        {
            try
            {
                if (queryValue == null || queryValue.Count <= 0) return false;
                string queryWhereStr = "1 = 1";
                bool isDelete = false;
                foreach (var item in queryValue)
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value == null ? "" : item.Value.ToString())) continue;
                    if (!EntityMap.ContainsKey(item.Key)) continue;
                    queryWhereStr += " and " + item.Key + " = " + "'" + item.Value + "'";
                    isDelete = true;
                }

                if (queryValue.ContainsKey("startTime") && queryValue.ContainsKey("endTime"))
                {
                    queryWhereStr += " and create_time >= '" + queryValue["startTime"] + "' and create_time <= '" + queryValue["endTime"] + "'";
                    isDelete = true;
                }
                if (!isDelete) return false;
                var res = EntityMgr.Db.Deleteable<nmfs_task>()
                    .Where(queryWhereStr)
                  .ExecuteCommand();
                return res > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }

        }

        /// <summary>
        /// 初始化表 表中数据全部清空，清除，自增初始化
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static bool DeleteAll()
        {
            try
            {
                var res = EntityMgr.Db.DbMaintenance.TruncateTable<nmfs_task>();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 判断实体类是否存在单条数据
        /// </summary>
        /// <param name="entity">条件</param>
        /// <param name="returnEntity">结果</param>
        /// <returns>备注</returns>
        public static bool IsExistSingleDataByEntity(nmfs_task entity, out nmfs_task returnEntity)
        {
            try
            {
                returnEntity = new nmfs_task();
                List<IConditionalModel> conModels = new List<IConditionalModel>();
                foreach (var item in ToMap(entity))
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value == null ? "" : item.Value.ToString())) continue;
                    if (!EntityMap.ContainsKey(item.Key)) continue;
                    conModels.Add(new ConditionalModel() { FieldName = item.Key, ConditionalType = ConditionalType.Equal, FieldValue = item.Value.ToString() });
                }

                var res = EntityMgr.Db.Queryable<nmfs_task>().Where(conModels)
                    .ToList();
                if (res.Count == 1)
                {
                    returnEntity = res.First();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }
    }
}