using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
public class DbContext<T> where T : class, new()
{
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = @"Data Source=DB_nMFStageWeb220CE.db; uid=root;pwd=system2019;database=DB_nMFStageWeb220CE.db",
            DbType = DbType.Sqlite,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }
    //注意：不能写成静态的
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
	public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

   public SimpleClient<nmfs_container> nmfs_containerDb { get { return new SimpleClient<nmfs_container>(Db); } }//用来处理nmfs_container表的常用操作
   public SimpleClient<nmfs_current_open_task> nmfs_current_open_taskDb { get { return new SimpleClient<nmfs_current_open_task>(Db); } }//用来处理nmfs_current_open_task表的常用操作
   public SimpleClient<nmfs_flow_records> nmfs_flow_recordsDb { get { return new SimpleClient<nmfs_flow_records>(Db); } }//用来处理nmfs_flow_records表的常用操作
   public SimpleClient<nmfs_log> nmfs_logDb { get { return new SimpleClient<nmfs_log>(Db); } }//用来处理nmfs_log表的常用操作
   public SimpleClient<nmfs_parameters> nmfs_parametersDb { get { return new SimpleClient<nmfs_parameters>(Db); } }//用来处理nmfs_parameters表的常用操作
   public SimpleClient<nmfs_task> nmfs_taskDb { get { return new SimpleClient<nmfs_task>(Db); } }//用来处理nmfs_task表的常用操作
   public SimpleClient<nmfs_task_details> nmfs_task_detailsDb { get { return new SimpleClient<nmfs_task_details>(Db); } }//用来处理nmfs_task_details表的常用操作
   public SimpleClient<nmfs_terminal> nmfs_terminalDb { get { return new SimpleClient<nmfs_terminal>(Db); } }//用来处理nmfs_terminal表的常用操作
   public SimpleClient<nmfs_terminal_device> nmfs_terminal_deviceDb { get { return new SimpleClient<nmfs_terminal_device>(Db); } }//用来处理nmfs_terminal_device表的常用操作
   public SimpleClient<nmfs_user> nmfs_userDb { get { return new SimpleClient<nmfs_user>(Db); } }//用来处理nmfs_user表的常用操作
   public SimpleClient<root_gb2312> root_gb2312Db { get { return new SimpleClient<root_gb2312>(Db); } }//用来处理root_gb2312表的常用操作
   public SimpleClient<root_serial_number> root_serial_numberDb { get { return new SimpleClient<root_serial_number>(Db); } }//用来处理root_serial_number表的常用操作
   public SimpleClient<sys_log> sys_logDb { get { return new SimpleClient<sys_log>(Db); } }//用来处理sys_log表的常用操作
   public SimpleClient<sys_upload_data> sys_upload_dataDb { get { return new SimpleClient<sys_upload_data>(Db); } }//用来处理sys_upload_data表的常用操作


   /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList()
    {
        return CurrentDb.GetList();
    }

    /// <summary>
    /// 根据表达式查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.GetList(whereExpression);
    }


    /// <summary>
    /// 根据表达式查询分页
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel);
    }

    /// <summary>
    /// 根据表达式查询分页并排序
    /// </summary>
    /// <param name="whereExpression">it</param>
    /// <param name="pageModel"></param>
    /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
    /// <param name="orderByType">OrderByType.Desc</param>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel,orderByExpression,orderByType);
    }


    /// <summary>
    /// 根据主键查询
    /// </summary>
    /// <returns></returns>
    public virtual T GetById(dynamic id)
    {
        return CurrentDb.GetById(id);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic id)
    {
        return CurrentDb.Delete(id);
    }


    /// <summary>
    /// 根据实体删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(T data)
    {
        return CurrentDb.Delete(data);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic[] ids)
    {
        return CurrentDb.AsDeleteable().In(ids).ExecuteCommand()>0;
    }

    /// <summary>
    /// 根据表达式删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.Delete(whereExpression);
    }


    /// <summary>
    /// 根据实体更新，实体需要有主键
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(T obj)
    {
        return CurrentDb.Update(obj);
    }

    /// <summary>
    ///批量更新
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(List<T> objs)
    {
        return CurrentDb.UpdateRange(objs);
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(T obj)
    {
        return CurrentDb.Insert(obj);
    }


    /// <summary>
    /// 批量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(List<T> objs)
    {
        return CurrentDb.InsertRange(objs);
    }


    //自已扩展更多方法 
}


