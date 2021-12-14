using System;
using Realms;

namespace frameworks.CSharp.Data
{
    public class DataManager
    {       
        public static Realm realm;

        public static Realm RealmInstance
        {
            get
            {
                if (realm == null)
                {
                    try
                    {
                        RealmConfiguration config = new RealmConfiguration
                        {
                            SchemaVersion = 3,
                            ShouldDeleteIfMigrationNeeded = true
                        };
                        realm = Realm.GetInstance(config);
                    }
                    catch
                    {
                        realm = Realm.GetInstance();
                    }
                }
                return realm;
            }
        }
    }
}
