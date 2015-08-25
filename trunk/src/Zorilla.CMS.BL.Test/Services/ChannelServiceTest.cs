using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;
using Zorilla.CMS.BL.Services;

namespace Zorilla.CMS.BL.Test.Services
{
    [TestFixture]
    public class ChannelServiceTest
    {
        private Channel root, channel1, channel11, channel2;

        private void CreateChannels()
        {
            channel11 = MockRepository.GenerateMock<Channel>();
            channel11.Name = "Channel 11";

            channel2 = MockRepository.GenerateMock<Channel>();
            channel2.Id = 2;
            channel2.Name = "Channel 2";
            channel2.Ordering = 2;


            channel1 = MockRepository.GenerateMock<Channel>();
            channel1.Id = 1;
            channel1.Name = "Channel 1";
            channel1.Ordering = 1;
            
            root = new Channel {Name = "Root", SubChannels = new List<Channel> {channel1, channel2}};
            channel11.Parent = channel1;
            channel1.Parent = root;
            channel2.Parent = root;

            root.SubChannels = new List<Channel>{channel1,channel2};
            channel1.SubChannels = new List<Channel>{channel11};
            channel2.SubChannels = new List<Channel>();
            channel11.SubChannels = new List<Channel>();
        }
       

        private ChannelService CreateChannelService()
        {
            var repository = MockRepository.GenerateStub<IChannelRepository>();
            repository.Stub(r => r.GetAll()).Return(new List<Channel> {root, channel1, channel2, channel11});
            return new ChannelService(repository);
        }

        [Test]
        public void GetRoot()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();
            Assert.AreEqual (root, service.GetRoot());
        }

        [Test]
        public void OrderingMoveDown()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();
            service.OrderingMoveDown(channel1);

            channel1.AssertWasCalled(c => c.Update());
            channel2.AssertWasCalled(c => c.Update());

            Assert.AreEqual(2,channel1.Ordering);
            Assert.AreEqual(1, channel2.Ordering);
        }

        [Test]
        public void OrderingMoveUp()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();
            service.OrderingMoveUp(channel2);

            channel1.AssertWasCalled(c => c.Update());
            channel2.AssertWasCalled(c => c.Update());

            Assert.AreEqual(2, channel1.Ordering);
            Assert.AreEqual(1, channel2.Ordering);
        }

        [Test]
        public void OrderingMoveDown_When_Down()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();
            service.OrderingMoveDown(channel2);

            Assert.AreEqual(1, channel1.Ordering);
            Assert.AreEqual(2, channel2.Ordering);
        }

        [Test]
        public void Create_New_Channel_Ordering()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();
            
            var newchannel = MockRepository.GenerateStub<Channel>();
            newchannel.Name = "new";
            newchannel.Parent = root;
            newchannel.TextId = "whatever";

            service.Create(newchannel);

            // assertions
            newchannel.AssertWasCalled(c => c.Create());
            Assert.AreEqual(3,newchannel.Ordering);
        }

        [Test]
        public void Create_New_Channel_Ordering_When_No_Siblings()
        {
            CreateChannels();
            ChannelService service = CreateChannelService();

            var newchannel = MockRepository.GenerateStub<Channel>();
            newchannel.Name = "new";
            newchannel.Parent = channel2;
            newchannel.TextId = "whatever";

            service.Create(newchannel);

            // assertions
            newchannel.AssertWasCalled(c => c.Create());
            Assert.AreEqual(1, newchannel.Ordering);
        }
    }
}
