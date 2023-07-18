
namespace SystemVentas.Application.Core
{
    public abstract class BaseService<TModelAdd, TModelMod, TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetInactive();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Remove(TModelRem model);
    }
}
