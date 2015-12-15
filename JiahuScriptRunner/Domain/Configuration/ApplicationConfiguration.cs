using System.ComponentModel;

namespace JiahuScriptRunner.Domain.Configuration
{
    public class ApplicationConfiguration
    {
        private string _scriptLocaction;
        private string _saveLocaction;
        private string _externalObjectUnderlyingDataLocation;

        [Browsable(false)]
        public bool HasChanged { get; private set; }

        [Browsable(true)]
        [Description("Location of the Jiahu Script Assembly.")]
        [Category("Jaihu")]
        public string ScriptLocaction
        {
            get { return _scriptLocaction; }
            set
            {
                HasChanged = true;
                _scriptLocaction = value;
            }
        }

        [Browsable(true)]
        [Description("Location of the Object Underlying Data.")]
        [Category("External Data")]
        public string ExternalObjectUnderlyingDataLocation
        {
            get { return _externalObjectUnderlyingDataLocation; }
            set
            {
                HasChanged = true;
                _externalObjectUnderlyingDataLocation = value;
            }
        }

        [Browsable(false)]
        public string SaveLocation
        {
            get { return _saveLocaction; }
            set
            {
                HasChanged = true;
                _saveLocaction = value;
            }
        }
    }
}
