using System;

namespace KartWebStoreTest
{
    public  class BaseTest
    {
        protected IServiceProvider serviceProvider { get; set; }    

        public BaseTest()
        {
            serviceProvider = TestStartUp.BootStrap();
        }
    }
}
