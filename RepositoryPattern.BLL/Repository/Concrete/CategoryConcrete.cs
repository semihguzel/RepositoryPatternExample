using RepositoryPattern.BLL.Repository.Abstract;
using RepositoryPattern.DAL;
using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Concrete
{
    public class CategoryConcrete : ICategory
    {
        //Bu class, IRepository icerisinde tanimlanan generic metodlardan ayri olarak sadece bu class icerisinde kullanilabilecek yapilar icin kullanilir.
        //IRepository icerisine Category entity'si yollandiginda IRepository icerisinde yazilan tum yapilar Category entity'si ile calisir.
        public IRepository<Category> _categoryRepository;
        public IUnitOfWork _categoryUnitOfWork;
        private DbContext _dbContext;

        public CategoryConcrete()
        {
            //Constructer icerisinde unitOfWork icerisine dbContext yollanir. Bunu bizim bildigimiz NorthwindEntities den olusturdugumuz db nesnesi olarak dusunebiliriz. categoryRepository ise bu db nesnesinin icerisinde bulunan db.Category tablosu gibidir. UnitOfWork icerisinde yazilmis olan GetRepository, alinan entity tipinde bir Repository dondurur. Bu sayede o entity ile hem Repository icerisinde yazilan generic crud islemleri, hem de UnitOfWork icerisinde yazilan saveChanges ve Dispose metodlari o entity icin ozel olarak kullanilabilir hale gelmis olur.
            _dbContext = new Context();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = _categoryUnitOfWork.GetRepository<Category>();
        }
        //Sadece bu class'a ozel olan metodlar ise burada normal olarak tanimlanir. CategoryConcrete class'i instance alindiginda buranin icerisinde yazilan metotlar (asagida yazilan 'CategoryIdByCategoryName') gozukur. Ayri olarak Repository ve UnitOfWork icerisindeki metodlar kullanilmak istendiginde, bu class icerisinde tanimlanan _categoryRepository veya _categoryUnitOfWork ile sadece bu entity'e ozel islemler kullanilabilir.
        public int CategoryIdByCategoryName(string categoryName)
        {
            return _categoryRepository.GetEntity().Where(x => x.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefault().CategoryID;
        }
    }
}
