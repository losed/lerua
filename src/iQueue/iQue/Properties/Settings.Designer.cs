﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iQueue.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("iQueue.db")]
        public string dbFilePath {
            get {
                return ((string)(this["dbFilePath"]));
            }
            set {
                this["dbFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("80")]
        public int webServicePort {
            get {
                return ((int)(this["webServicePort"]));
            }
            set {
                this["webServicePort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("logs")]
        public string logDirectoryPath {
            get {
                return ((string)(this["logDirectoryPath"]));
            }
            set {
                this["logDirectoryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool serverAutoStart {
            get {
                return ((bool)(this["serverAutoStart"]));
            }
            set {
                this["serverAutoStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string webServiceAddress {
            get {
                return ((string)(this["webServiceAddress"]));
            }
            set {
                this["webServiceAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("status")]
        public string statusDirectoryPath {
            get {
                return ((string)(this["statusDirectoryPath"]));
            }
            set {
                this["statusDirectoryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ledThreadsAutoStart {
            get {
                return ((bool)(this["ledThreadsAutoStart"]));
            }
            set {
                this["ledThreadsAutoStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("templates")]
        public string tplDirPath {
            get {
                return ((string)(this["tplDirPath"]));
            }
            set {
                this["tplDirPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BEGIN TRANSACTION;\r\nCREATE TABLE [events] (\r\n  [date] DATETIME NOT NULL DEFAULT (" +
            "datetime(CURRENT_TIMESTAMP, \'localtime\')), \r\n  [user] VARCHAR NOT NULL, \r\n  [vis" +
            "itor] VARCHAR NOT NULL, \r\n  [action] VARCHAR NOT NULL);\r\n\r\n\r\nCREATE TABLE [scree" +
            "ns] (\r\n  [id] INTEGER PRIMARY KEY AUTOINCREMENT, \r\n  [name] VARCHAR NOT NULL, \r\n" +
            "  [ip] VARCHAR(20), \r\n  [port] INTEGER NOT NULL DEFAULT 5005, \r\n  [behavior] INT" +
            "EGER NOT NULL DEFAULT 0, \r\n  [width] INTEGER DEFAULT 160, \r\n  [height] INTEGER D" +
            "EFAULT 48);\r\n\r\n\r\nCREATE TABLE [settings] (\r\n  [id] INTEGER NOT NULL PRIMARY KEY " +
            "AUTOINCREMENT, \r\n  [user] INTEGER NOT NULL DEFAULT 0, \r\n  [screen] INTEGER NOT N" +
            "ULL DEFAULT 0, \r\n  [key] VARCHAR(128) NOT NULL, \r\n  [name] VARCHAR(1024), \r\n  [v" +
            "alue] TEXT, \r\n  [type] VARCHAR NOT NULL DEFAULT text);\r\n\r\nCREATE UNIQUE INDEX [s" +
            "ettUniq] ON [settings] ([user], [screen], [key]);\r\nINSERT INTO \"settings\" VALUES" +
            "(1,0,0,\'playSound\',\'Проигрывать звук (1-да, 0-нет)\',\'0\',\'number\');\r\nINSERT INTO " +
            "\"settings\" VALUES(2,0,0,\'setExpiryTimeout\',\'Пометить заказ как задержанный через" +
            ", минут\',\'15\',\'number\');\r\nINSERT INTO \"settings\" VALUES(3,0,0,\'doneVisibleTimeou" +
            "t\',\'Отображение номера после готовности, минут\',\'1\',\'number\');\r\nINSERT INTO \"set" +
            "tings\" VALUES(4,0,0,\'stuntCode\',\'Эффект анимации (формат HEX: STRING)\',\'0x02: DI" +
            "RECT_SHOW\',\'text\');\r\nINSERT INTO \"settings\" VALUES(5,0,0,\'scrollSpeed\',\'Коэффици" +
            "ент замедления анимации\',\'10\',\'number\');\r\nINSERT INTO \"settings\" VALUES(6,0,0,\'s" +
            "crollDelay\',\'Время отображения кадра на экране, секунд\',\'5\',\'number\');\r\nINSERT I" +
            "NTO \"settings\" VALUES(7,0,0,\'fontFamily\',\'Шрифт текста на экранах\',\'Tahoma\',\'tex" +
            "t\');\r\nINSERT INTO \"settings\" VALUES(8,0,0,\'fontSize\',\'Размер шрифта на экранах, " +
            "pt\',\'10\',\'number\');\r\nINSERT INTO \"settings\" VALUES(9,0,0,\'ledRefreshTimeout\',\'Пе" +
            "риодичность обновления экранов, секунд\',\'10\',\'number\');\r\nINSERT INTO \"settings\" " +
            "VALUES(10,0,0,\'adminPasswd\',\'Пароль администратора\',\'leroyMerlin\',\'text\');\r\nINSE" +
            "RT INTO \"settings\" VALUES(11,0,0,\'idlePlayAdRtf\',\'Отображать рекламное содержимо" +
            "е при отсутствии посетителей (1-да, 0-нет)\',\'1\',\'number\');\r\n\r\n\r\nCREATE TABLE [us" +
            "ers] (\r\n[id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \r\n[login] VARCHAR(128) " +
            "NOT NULL ON CONFLICT FAIL, \r\n[password] VARCHAR(32) NOT NULL, \r\n[role] INT(2) NO" +
            "T NULL DEFAULT 0);\r\n\r\nCREATE UNIQUE INDEX [loginUniq] ON [users] ([login]);\r\nINS" +
            "ERT INTO \"users\" VALUES(1,\'admin\',\'21232f297a57a5a743894a0e4a801fc3\',100);\r\n\r\nCR" +
            "EATE TABLE [visitors] (\r\n  [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \r\n  " +
            "[number] VARCHAR NOT NULL, \r\n  [status] INTEGER NOT NULL DEFAULT 0, \r\n  [start] " +
            "DATETIME NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP, \'localtime\')), \r\n  [done]" +
            " DATETIME  NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP, \'localtime\')), \r\n  [end" +
            "] DATETIME);\r\n\r\nCREATE TRIGGER [newVisitor]\r\nAFTER INSERT\r\nON [visitors]\r\nFOR EA" +
            "CH ROW\r\nBEGIN\r\n  INSERT INTO events (user,visitor,action) VALUES (\'admin\',new.nu" +
            "mber,\'Добавлен новый талон\');\r\nEND;\r\n\r\nCREATE TRIGGER [endVisitor]\r\nAFTER UPDATE" +
            " OF [status]\r\nON [visitors]\r\nFOR EACH ROW\r\nWHEN new.status=2 AND old.status!=2\r\n" +
            "BEGIN\r\n    INSERT INTO events (user,visitor,action) VALUES (\'admin\',new.number,\'" +
            "Статус заказа по талону изменился на ГОТОВ.\');    \r\nEND;\r\n\r\nCREATE TRIGGER [delV" +
            "isitor]\r\nAFTER UPDATE OF [status]\r\nON [visitors]\r\nFOR EACH ROW\r\nWHEN new.status=" +
            "-1 AND old.status!=-1\r\nBEGIN\r\n  INSERT INTO events (user,visitor,action) VALUES " +
            "(\'admin\',new.number,\'Талон отмечен на удаление.\');\r\nEND;\r\n\r\nCREATE TRIGGER [drop" +
            "Visitor]\r\nAFTER DELETE\r\nON [visitors]\r\nFOR EACH ROW\r\nBEGIN\r\n INSERT INTO events " +
            "(user,visitor,action) VALUES (\'admin\',old.number,\'Удален талон.\');\r\nEND;\r\n\r\nCREA" +
            "TE TRIGGER [lateVisitor]\r\nAFTER UPDATE OF [end]\r\nON [visitors]\r\nFOR EACH ROW\r\nWH" +
            "EN old.\'end\' is null and new.\'end\' is not null\r\nBEGIN\r\n INSERT INTO events (user" +
            ",visitor,action) VALUES (\'admin\',new.number,\'Заказ по талону обслуживался \'||(st" +
            "rftime(\'%s\',new.end) - strftime(\'%s\',new.start))||\' секунд \' );\r\nEND;\r\n\r\nCREATE " +
            "UNIQUE INDEX [uniqTalon] ON [visitors] ([number]);\r\nCOMMIT;")]
        public string initialDBStructure {
            get {
                return ((string)(this["initialDBStructure"]));
            }
            set {
                this["initialDBStructure"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool softActivated {
            get {
                return ((bool)(this["softActivated"]));
            }
            set {
                this["softActivated"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string softCode {
            get {
                return ((string)(this["softCode"]));
            }
            set {
                this["softCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://0977.ru/soft/updates/iQueue/update.php")]
        public string updateUrl {
            get {
                return ((string)(this["updateUrl"]));
            }
            set {
                this["updateUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://0977.ru/soft/reg.php")]
        public string regUrl {
            get {
                return ((string)(this["regUrl"]));
            }
            set {
                this["regUrl"] = value;
            }
        }
    }
}
