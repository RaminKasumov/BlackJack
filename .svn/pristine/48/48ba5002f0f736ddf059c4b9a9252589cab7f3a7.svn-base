
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Singleton wird angewendet (Instanz von der Klasse wird in einer Instanzvariable gespeichert und mithilfe einer statischen Methode zurückgeliefert)
    /// Es gibt auch eine Instanzvariable für die Konfiguration des Spiels und wird mithilfe einer Methode ausgegeben
    /// </summary>
    public class Settings
    {
        #region instancevariables
        /// <summary>
        /// Der Instanz von dieser Klasse wird in einer Instanzvariable gespeichert
        /// </summary>
        static readonly Settings Instance = new Settings();

        /// <summary>
        /// Eine Instanzvariable wird für die Konfiguration des Spiels BlackJack erstellt
        /// </summary>
        readonly IGameConfig _gameConfig = new GameConfig();
        #endregion

        #region constructor
        private Settings()
        {
            
        }
        #endregion

        #region methods
        /// <summary>
        /// Die statische Methode liefert den Instanzen von dieser Klasse zurück
        /// </summary>
        /// <returns>Der Instanz von dieser Klasse wird ausgegeben</returns>
        public static Settings GetInstance()
        {
            return Instance;
        }

        /// <summary>
        /// Die Methode liefert die Konfiguration des Spiels zurück
        /// </summary>
        /// <returns>Die Konfiguration des Spiels BlackJack wird ausgegeben</returns>
        public IGameConfig GetGameConfig()
        {
            return _gameConfig;
        }
        #endregion
    }
}