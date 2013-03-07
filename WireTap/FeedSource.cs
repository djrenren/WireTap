using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WireTap
{
    class FeedSource : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Uri Source { get; set; }
        public DateTime LastUpdated { get; private set; }
        private ObservableCollection<FeedItem> _Items { get; set; }
        public ObservableCollection<FeedItem> Items
        {
            get
            {
                return _Items;
            }
        }

        public FeedSource(string name, Uri source)
        {
            Name = name;
            Source = source;
        }

        public void Update() {
            _Items.Clear();

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(Source);

        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

        }

    }
}
