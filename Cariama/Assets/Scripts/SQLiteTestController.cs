using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SQLiteTestController : MonoBehaviour
    {
        public bool isInitializated;

        [SerializeField] Toggle toggleHaveSound;
        [SerializeField] InputField infName;
        [SerializeField] InputField infScore;
        // Use this for initialization
        void Start()
        {
            SQLiteManager.SetDatabase();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SubmitData(string occasion)
        {
            switch(occasion)
            {
                case "options": break;
                case "leaderboard": break;
                default: Debug.LogError("occasion invalid."); break;
            }
        }

        private void SaveOptions()
        {
            if (toggleHaveSound.isOn) SQLiteManager.RunQuery(CommonQuery.Update("OPTIONS", "SOUND = 1", "SOUND = 1"));
            else SQLiteManager.RunQuery(CommonQuery.Update("OPTIONS", "SOUND = 1", "SOUND = 0"));

            Debug.Log("Som foi salvo.");
        }

        private void SaveLeaderboard()
        {
            if(infName.text != string.Empty && infScore.text != string.Empty) SQLiteManager.RunQuery(CommonQuery.Add("LEADERBOARD", "NAME, SCORE", $"'{infName.text}', {infScore.text}"));
            Debug.Log("Leaderboard foi salvo.");
        }

        private void LoadOptions()
        {
            bool act = SQLiteManager.ReturnValueAsInt(CommonQuery.Select("SOUND", "OPTIONS")) == 1;
            toggleHaveSound.isOn = act;
            string actived = act ? "ativo" : "desativo";
            Debug.Log($"O som está {actived}");
        }

        private void LoadLeaderboard()
        {
            List<LeaderboardDemo> leaderboard = SQLiteManager.ReturnValueAsListOfString(CommonQuery.Select("NAME, SCORE", "NAME = NAME ORDER BY SCORE ASC LIMIT 10"));

            foreach(var L in leaderboard)
            {
                Debug.Log($"nome: {L.Name}, pontuação: {L.Score}");
            }
        }

    }
}