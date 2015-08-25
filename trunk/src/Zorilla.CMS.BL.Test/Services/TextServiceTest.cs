using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;
using Rhino.Mocks;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;
using Zorilla.CMS.BL.Services;

namespace Zorilla.CMS.BL.Test.Services
{
    [TestFixture]
    public class TextServiceTest
    {
        private Language da;
        private Language en;
        private Text[] texts;
        private ITextRepository textRepository;
        private TextService textService;

        [TestFixtureSetUp]
        public void SetUp()
        {
            da = new Language();
            da.Id = 1;
            da.LanguageCode = "DA";
            da.Name = "Dansk";

            en = new Language();
            en.Id = 2;
            en.LanguageCode = "EN";
            en.Name = "English";
                
            texts = new[] {
                new Text{Language = da,TextId = "TextId1",Value = "Text1Da"},
                new Text{Language = en,TextId = "TextId1",Value = "Text1En"},
                new Text{Language = da,TextId = "TextId2",Value = "Text2Da"},
            };

            textRepository = MockRepository.GenerateStub<ITextRepository>();
            textRepository.Stub(t => t.Query).Return(texts.AsQueryable());

            var sessionProvider = MockRepository.GenerateStub<ISessionProvider>();
            sessionProvider.Stub(sp => sp.GetSession()).Return(MockRepository.GenerateStub<IDisposable>());

            textService = new TextService(textRepository,sessionProvider);
        }

        [Test]
        public void get_texts()
        {
            Assert.AreEqual("Text1Da",textService.GetText("TextId1", da).Value);
            Assert.AreEqual("Text1En", textService.GetText("TextId1", en).Value);
            Assert.AreEqual("_?badid,English?_", textService.GetText("badid", en).Value);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void get_text_null_language()
        {
            textService.GetText("TextId1", null);
        }
    }
}
