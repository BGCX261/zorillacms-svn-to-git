using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Zorilla.CMS.BL.Context;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.BL.Services
{
    public interface ITextService
    {
        Text GetText(string key, Language lang);
        Text GetText(string key);
        void CreateOrUpdate(Text txt);
    }

    public class TextService : ITextService
    {
        private readonly ITextRepository textRepository;
        private readonly ISessionProvider sessionProvider;

        public TextService(ITextRepository textRepository, ISessionProvider sessionProvider)
        {
            this.textRepository = textRepository;
            this.sessionProvider = sessionProvider;
        }

        public Text GetText(string key, Language lang)
        {
            if (lang == null) throw new ArgumentNullException("lang");

            using (sessionProvider.GetSession())
            {
                Text text = textRepository.Query.FirstOrDefault(t => t.TextId == key && t.Language.Id == lang.Id);
                if (text == null) return new Text {Value = "_?" + key + "," + lang + "?_", Language = lang, TextId = key};
                return text;
            }
        }

        public Text GetText(string key)
        {
            return GetText(key, CmsContext.Current.Language);
        }

        public void CreateOrUpdate(Text txt)
        {
            if (txt.IsCreated) txt.Update();
            else txt.Create();
        }
    }

    
}
