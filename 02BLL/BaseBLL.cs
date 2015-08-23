using _03DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _02BLL
{
    public class BaseBLL<T> where T : class
    {
        private BaseDAL<T> baseDal = new BaseDAL<T>();
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否成功</returns>
        public bool Add(T entity)
        {
            try
            {
                this.baseDal.Add(entity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
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
                this.baseDal.AddList(listEntity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
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
                this.baseDal.Delete(entity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
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
                this.baseDal.DeleteList(listEntity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
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
                this.baseDal.Update(entity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
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
                this.baseDal.UpdateList(listEntity);
                return baseDal.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="whereLambda">不定个数的条件</param>
        /// <returns>查询结果表示树</returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                return this.baseDal.Query(whereLambda);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="whereLambda">不定个数的条件</param>
        /// <returns>查询结果表示树</returns>
        public IQueryable<T> QueryNoTracking(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                return this.baseDal.QueryNoTracking(whereLambda);
            }
            catch (Exception)
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
        public IQueryable<T> QueryPartial<Tkey>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba,
            Expression<Func<T, Tkey>> orderby, bool isAsc
)
        {
            try
            {
                return this.baseDal.QueryPartial<Tkey>(pageIndex, pageSize, out totalRecord, whereLamdba, orderby, isAsc);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
