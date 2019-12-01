using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Restaurant1.Classes;
using System.Runtime.Serialization.Formatters.Binary;

namespace Restaurant1.DataHandlers
{
    class BinarySerializer
    {
        private string path;
        private BinaryFormatter bf;
        public BinarySerializer(string path)
        {
            bf = new BinaryFormatter();
            this.path = path;
        }
        public Kitchen Read()
        {
            Kitchen kitchen = null;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                kitchen = (Kitchen)bf.Deserialize(stream);
            }
            return kitchen;
        }
        public void Write(Kitchen kitchen)
        {
            using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                bf.Serialize(stream, kitchen);
            }
        }

    }

}
