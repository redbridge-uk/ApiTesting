using System;
using System.Collections.Generic;

namespace Redbridge.ApiTesting.Framework
{
    public class EntityCache<T>
    {
        private readonly Func<IEnumerable<T>> _cacheLoadRequest;
        private bool _cacheLoaded;
        private readonly List<T> _entities = new List<T>();

        public EntityCache(Func<IEnumerable<T>> cacheLoadRequest)
        {
            _cacheLoadRequest = cacheLoadRequest ?? throw new ArgumentNullException(nameof(cacheLoadRequest));
        }

        public void Load(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            _entities.Clear();
            _entities.AddRange(items);
            _cacheLoaded = true;
        }

        public void Clear()
        {
            _entities.Clear();
            _cacheLoaded = false;
        }

        public IEnumerable<T> Items
        {
            get
            {
                if ( !_cacheLoaded )
                    Load(_cacheLoadRequest());

                return _entities;
            }
        }
    }
}
