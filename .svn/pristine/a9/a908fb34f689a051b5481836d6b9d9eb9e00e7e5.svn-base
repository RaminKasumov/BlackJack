
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Es gibt einige Methoden für das Spiel, die von der Klasse Game implementiert und verwendet werden
    /// </summary>
    public interface IGame
    {
        #region properties
        /// <summary>
        /// Eigenschaft für den Spieler
        /// </summary>
        IPlayer Player { get; }

        /// <summary>
        /// Eigenschaft für den Dealer des Spiels
        /// </summary>
        IPlayer Dealer { get; }
        #endregion

        #region events
        event EventHandler GameStarted;

        event EventHandler<PlayerEventArgs> PlayerActionPerformed;

        event EventHandler DealerActionPerformed;

        event EventHandler GameFinished;

        event EventHandler GameClosed;
        #endregion

        #region methods
        /// <summary>
        /// Das Spiel wird gestartet (Spieler und Dealer kriegen jeweils zwei Karten)
        /// </summary>
        void StartGame();

        /// <summary>
        /// Nächste Aktion wird von der Strategie bestimmt
        /// </summary>
        void Play();

        /// <summary>
        /// Mithilfe des eingegebenen Aktions vom Spieler geht das Spiel weiter
        /// </summary>
        /// <param name="action">Aktion des Spielers</param>
        /// <param name="secondHand">Zweite Hand</param>
        void Play(PlayerAction action, bool secondHand);

        /// <summary>
        /// Das Spiel wird bis zum Ende gespielt
        /// </summary>
        void PlayGameToEnd();

        /// <summary>
        /// Gewinner des Spiels wird ausgegeben
        /// </summary>
        /// <returns>Liefert den richtigen Gewinner des Spiels zurück</returns>
        GameWinner GetWinner();

        /// <summary>
        /// Gewinnrate des Spielers
        /// </summary>
        /// <returns>Liefert die Gewinnrate des Spielers zurück</returns>
        double GetWinRatio();

        /// <summary>
        /// Gewinner des Spiels wird ausgegeben
        /// </summary>
        /// <returns>Liefert den richtigen Gewinner des Spiels zurück</returns>
        GameWinner GetSecondHandWinner();

        /// <summary>
        /// Gewinnrate des Spielers (zweite Hand)
        /// </summary>
        /// <returns>Liefert die Gewinnrate des Spielers für die zweite Hand zurück</returns>
        double GetSecondHandWinRatio();

        /// <summary>
        /// Gibt Informationen über das Spiel und die Gewinner aus
        /// </summary>
        /// <returns>Liefert Informationen über den Spielablauf zurück</returns>
        string ToString();
        #endregion
    }
}