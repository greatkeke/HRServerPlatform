using _04Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _03DAL
{
    public class BaseDAL<T> where T:class
    {
        /// <summary>
        /// 获取线程中实例唯一的上下文
        /// </summary>
        private DbContext _db = ModelFactory.GetContext();
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否成功</returns>
        public bool Add(T entity)
        {
            try
            {
                this._db.Set<T>().Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 增加实体集合
        /// </summary>
        /// <param name="listEntity">实体集合</param>
        /// <returns>是否成功</returns>
        public bool AddList(List<T> listEntity)
        {
            try
            {
                foreach (var item in listEntity)
                {
                    this._db.Set<T>().Add(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否成功</returns>
        public bool Delete(T entity)
        {
            try
            {
                this._db.Set<T>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="listEntity">实体集合</param>
        /// <returns>是否成功</returns>
        public bool DeleteList(List<T> listEntity)
        {
            try
            {
                foreach (var item in listEntity)
                {
                    this._db.Set<T>().Remove(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否成功</returns>
        public bool Update(T entity)
        {
            try
            {
                this._db.Entry<T>(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="listEntity">实体集合</param>
        /// <returns>是否成功</returns>
        public bool UpdateList(List<T> listEntity)
        {
            try
            {
                foreach (var item in listEntity)
                {
                    this._db.Entry<T>(item).State = EntityState.Modified;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="whereLambda">不定个数的条件</param>
        /// <returns>查询结果表示树</returns>
        public IQueryable<T> Query(Func<T, bool> whereLambda)
        {
            try
            {
                return this._db.Set<T>().Where(whereLambda).AsQueryable<T>();
            }
            catch
            {

                throw;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">步长</param>
        /// <param name="totalRecord">总页数</param>
        /// <param name="whereLamdba">条件</param>
        /// <param name="orderby">排序依据</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>查询结果表达式树</returns>
        public IQueryable<T> QueryPartial<Tkey>(int pageIndex, int pageSize, out int totalRecord, System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, System.Linq.Expressions.Expression<Func<T, Tkey>> orderby, bool isAsc)
        {
            try
            {
                //总数
                totalRecord = this._db.Set<T>().Count();
                //判断是否升序
                if (isAsc)
                {
                    //升序分页
                    return this._db.Set<T>().Where(whereLamdba).OrderBy<T, Tkey>(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable<T>();
                }
                else
                {
                    //降序分页
                    return this._db.Set<T>().Where(whereLamdba).OrderByDescending<T, Tkey>(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable<T>();
                }

            }
            catch
            {

                throw;
            }
        }
    }
}
