using Model;
using Newtonsoft.Json;
using NTDCommLib;
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
    public class NmfsCurrentOpenTaskService
    {
        private static readonly nmfs_current_open_taskManager EntityMgr = new nmfs_current_open_taskManager();

        /// <summary>
        /// 得到实体类转成Dic
        /// </summary>
        private static Dictionary<string, object> EntityMap = ToMap(new nmfs_current_open_task());

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
        public static nmfs_current_open_task GetOneDataByPrimaryKey(object o)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
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
        public static List<nmfs_current_open_task> GetDataByNumber(int maxUpDataCount)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
                  .Take(maxUpDataCount)
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
        public static List<nmfs_current_open_task> GetData()
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
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
        public static List<nmfs_current_open_task> GetDataByEntity(nmfs_current_open_task entity)
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
        public static List<nmfs_current_open_task> GetDataByDic(Dictionary<string, object> queryValue, ConditionalType conditionalType = ConditionalType.Equal)
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

                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>().Where(conModels)
                  .WhereIF(queryValue.ContainsKey("startTime") && queryValue.ContainsKey("endTime"), it => SqlFunc.Between(it.create_time, queryValue["startTime"], queryValue["endTime"]))
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
        public static List<nmfs_current_open_task> GetPageDataByEntity(int currentPageIndex, int pageSize, ref int totalCount, nmfs_current_open_task entity)
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
        public static List<nmfs_current_open_task> GetPageDataByDic(int currentPageIndex, int pageSize, ref int totalCount, Dictionary<string, object> queryValue, ConditionalType conditionalType = ConditionalType.Equal)
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

                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>().Where(conModels)
                  .WhereIF(queryValue.ContainsKey("startTime") && queryValue.ContainsKey("endTime"), it => SqlFunc.Between(it.create_time, queryValue["startTime"], queryValue["endTime"]))
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
        public static bool Insert(nmfs_current_open_task entity)
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
        public static bool InsertByList(List<nmfs_current_open_task> entityList)
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

        public static bool Save(nmfs_current_open_task entity)
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
        public static bool Update(nmfs_current_open_task entity)
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
                var res = EntityMgr.Db.Deleteable<nmfs_current_open_task>().In(primaryKeyValue).ExecuteCommand();
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
                var res = EntityMgr.Db.Deleteable<nmfs_current_open_task>().In(primaryKeyValueArray).ExecuteCommand();
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
        public static bool DeleteByEntity(nmfs_current_open_task entity)
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
                var res = EntityMgr.Db.Deleteable<nmfs_current_open_task>()
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
                var res = EntityMgr.Db.DbMaintenance.TruncateTable<nmfs_current_open_task>();
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
        public static bool IsExistSingleDataByEntity(nmfs_current_open_task entity, out nmfs_current_open_task returnEntity)
        {
            try
            {
                returnEntity = new nmfs_current_open_task();
                List<IConditionalModel> conModels = new List<IConditionalModel>();
                foreach (var item in ToMap(entity))
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value == null ? "" : item.Value.ToString())) continue;
                    if (!EntityMap.ContainsKey(item.Key)) continue;
                    conModels.Add(new ConditionalModel() { FieldName = item.Key, ConditionalType = ConditionalType.Equal, FieldValue = item.Value.ToString() });
                }

                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>().Where(conModels)
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

        /// <summary>
        /// 获取第一个可用物料
        /// </summary>
        /// <param name="currentTask"></param>
        /// <returns></returns>
        public static nmfs_current_open_task GetFirstNotCompleteEntityByTask(nmfs_task currentTask, string batching_way)
        {
            try
            {
                 var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
                  .Where(it => it.task_serial_number == currentTask.serial_number && it.task_current_count < it.task_all_count)
                  .OrderByIF(batching_way== "ABC-ABC-ABC", it => it.task_current_count, OrderByType.Asc)
                  .OrderBy(it => it.task_details_sort, OrderByType.Asc)
                  .ToList();
                if (res.Count > 0)
                {
                    return res.First();
                }
                else
                {
                    return new nmfs_current_open_task();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 判断任务一轮是否完成,不包含任务完成情况
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="currentOpenTask"></param>
        /// <returns></returns>
        public static bool IsCompleteRoundTasks(nmfs_current_open_task currentOpenTask)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
                  .Where(it => it.task_serial_number == currentOpenTask.task_serial_number)
                .ToList();
                if (res.Count <= 0) return false;

                  var res1 = res.Where(it => it.task_current_count < it.task_all_count)
                   .Where(it => it.task_current_count == currentOpenTask.task_current_count)
                   .ToList();
                return res.Count == res1.Count;
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }
        /// <summary>
        /// 判断任务是否全部完成
        /// </summary>
        /// <param name="currentTask"></param>
        /// <returns></returns>
        public static bool IsCompleteTaskByTask(nmfs_task currentTask)
        {
            try
            {
                var res = EntityMgr.Db.Queryable<nmfs_current_open_task>()
                  .Where(it => it.task_serial_number == currentTask.serial_number)
                .Where(it => it.task_all_count > it.task_current_count)
                .ToList();
                if (res.Count == 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 获取当前物料的下一个物料
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="currentOpenTask"></param>
        /// <param name="currentTask"></param>
        /// <returns></returns>
        public static nmfs_current_open_task GetNetEntityByEntity(nmfs_current_open_task currentOpenTask, string batching_way)
        {
            try
            {
                //查询当前任务的所有物料
               var  currentOpenTaskList = EntityMgr.Db.Queryable<nmfs_current_open_task>()
                .Where(it => it.task_serial_number == currentOpenTask.task_serial_number)
               .ToList();
                if (currentOpenTaskList == null || currentOpenTaskList.Count <= 0) return new nmfs_current_open_task();


                //查询任务物料未完成的数量
                var  tempCurrentOpenTaskList = currentOpenTaskList.Where(it => it.task_current_count < it.task_all_count).ToList();

                switch (batching_way)
                {
                    default:
                    case ("AAA-BBB-CCC")://AAA-BBB-CCC

                        //判断任务全部完成
                        if (tempCurrentOpenTaskList.Count() <= 0)
                        {
                            return new nmfs_current_open_task();
                        }
                        else
                        {
                            //判断当前任务是否为单物料
                            if (currentOpenTaskList.Count() <= 1)
                            {
                                if (currentOpenTask.task_current_count + 1 >= currentOpenTask.task_all_count)
                                {
                                    return new nmfs_current_open_task();
                                }
                                else
                                {
                                    return currentOpenTask;
                                }
                            }
                            else
                            {
                                //判断是否为最后未完成一个物料
                                if (tempCurrentOpenTaskList.Count <= 1)
                                {
                                    if (currentOpenTask.task_current_count + 1 >= currentOpenTask.task_all_count)
                                    {
                                        return new nmfs_current_open_task();
                                    }
                                    else
                                    {
                                        return currentOpenTask;
                                    }
                                }
                                else
                                {
                                    if (currentOpenTask.task_current_count + 1 >= currentOpenTask.task_all_count)
                                    {
                                        currentOpenTaskList = tempCurrentOpenTaskList;
                                    }
                                    else
                                    {
                                        return currentOpenTask;
                                    }
                                }
                            }
                        }
                        break;
                    case ("ABC-ABC-ABC")://ABC-ABC-ABC(需要验证完成数量是否相同)  

                        //判断任务全部完成
                        if (tempCurrentOpenTaskList.Count() <= 0)
                        {
                            return new nmfs_current_open_task();
                        }
                        else
                        {
                            //判断当前任务是否为单物料
                            if (currentOpenTaskList.Count() <= 1)
                            {
                                if (currentOpenTask.task_current_count + 1 >= currentOpenTask.task_all_count)
                                {
                                    return new nmfs_current_open_task();
                                }
                                else
                                {
                                    return currentOpenTask;
                                }
                            }
                            else
                            {
                                //判断是否为最后未完成一个物料
                                if (tempCurrentOpenTaskList.Count <= 1)
                                {
                                    if (currentOpenTask.task_current_count + 1 >= currentOpenTask.task_all_count)
                                    {
                                        return new nmfs_current_open_task();
                                    }
                                    else
                                    {
                                        return currentOpenTask;
                                    }
                                }
                                else
                                {
                                    tempCurrentOpenTaskList = tempCurrentOpenTaskList.Where(it => it.task_current_count == currentOpenTask.task_current_count).ToList();
                                    if (tempCurrentOpenTaskList.Count > 1)
                                    {
                                        currentOpenTaskList = tempCurrentOpenTaskList;
                                    }
                                }
                            }
                        }
                        break;
                }
                //根据选中数据重新排序
                if (currentOpenTaskList.Count > 1)
                {
                    int i = currentOpenTaskList.FindIndex(delegate (nmfs_current_open_task it)
                    {
                        return it.id == currentOpenTask.id;
                    });
                    //根据下标为开始数据重新排序
                    currentOpenTaskList = ListHelper.ReorderByIndex(currentOpenTaskList, i);
                    return currentOpenTaskList[1];
                }
                else
                {
                    return currentOpenTaskList[0];
                }
                //    return new tb_current_open_task();
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库操作出错：{ex.ToString()}");
            }
        }
    }
}