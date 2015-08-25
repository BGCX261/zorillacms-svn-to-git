using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.ActiveRecord;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.BL.Services
{
    public interface IChannelService
    {
        Channel GetRoot();

        Channel GetChannelByName(string name);
        Channel GetChannel(long id);
        IList<Channel> GetAll();
        IList<Channel> GetSiblings(Channel channel);
        void Create(Channel channel);
        Channel GetDefaultChannel();
        void OrderingMoveUp(Channel channel);
        void OrderingMoveDown(Channel channel);
    }


    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository channelRepository;

        public ChannelService(IChannelRepository channelRepository)
        {
            this.channelRepository = channelRepository;
        }
        
        public Channel GetRoot()
        {
            IList<Channel> all = channelRepository.GetAll();
            return all.First(c => c.Parent == null);
        }

        public Channel GetChannelByName(string name)
        {
            using (new SessionScope())
            {
                return channelRepository.Query.FirstOrDefault(c => c.Name == name);
            }
        }

        public Channel GetChannel(long id)
        {
            return channelRepository.GetByPrimaryKey(id);
        }

        public IList<Channel> GetAll() { return channelRepository.GetAll(); }
        public IList<Channel> GetSiblings(Channel channel)
        {
            if (channel.Parent == null) return new List<Channel>();
            return channel.Parent.SubChannels.Where(c => !c.Equals(channel)).ToList();
        }

        public void Create(Channel channel)
        {
            IList<Channel> siblings = GetSiblings(channel);
            if (siblings.Count == 0) channel.Ordering = 1;
            else channel.Ordering = siblings.Max(c => c.Ordering) + 1;
            channel.Create();
        }

        public Channel GetDefaultChannel()
        {
            return GetRoot().SubChannels.FirstOrDefault() ?? GetRoot();
        }

        public void OrderingMoveUp(Channel channel)
        {
            IList<Channel> siblings = GetSiblings(channel);
            Channel switcher =
                siblings.Where(c => c.Ordering < channel.Ordering).OrderBy(c => c.Ordering).FirstOrDefault();
            if (switcher != null)
            {
                int currentOrder = channel.Ordering;
                channel.Ordering = switcher.Ordering;
                switcher.Ordering = currentOrder;
                channel.Update();
                switcher.Update();
            }
        }

        public void OrderingMoveDown(Channel channel)
        {
            IList<Channel> siblings = GetSiblings(channel);
            Channel switcher =
                siblings.Where(c => c.Ordering > channel.Ordering).OrderBy(c => c.Ordering).FirstOrDefault();
            if (switcher != null)
            {
                int currentOrder = channel.Ordering;
                channel.Ordering = switcher.Ordering;
                switcher.Ordering = currentOrder;
                channel.Update();
                switcher.Update();
            }
        }
    }
}
