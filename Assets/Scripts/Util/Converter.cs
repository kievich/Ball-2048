using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Converter
    {
        private static Dictionary<BoosterType, RewardType> _boosterToReward;
        private static Dictionary<RewardType, AdType> _RewardToAdType;

        static Converter()
        {
            _boosterToReward = new Dictionary<BoosterType, RewardType>();
            _RewardToAdType = new Dictionary<RewardType, AdType>();

            _boosterToReward.Add(BoosterType.Bomb, RewardType.Bomb);
            _boosterToReward.Add(BoosterType.Doubler, RewardType.Doubler);

            _RewardToAdType.Add(RewardType.Bomb, AdType.BombReward);
            _RewardToAdType.Add(RewardType.Doubler, AdType.DoublerReward);
        }

        public static W ValueBuyKey<T, W>(this Dictionary<T, W> dict, T key)
        {
            W value = default;
            if (dict.TryGetValue(key, out value))
                return value;
            else
                throw new Exception("Can't Convert Key to Value. Dictionary: " + dict.ToString() + ". Key: " + key.ToString());
        }

        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;
            bool isKeyFound = false;

            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    isKeyFound = true;
                    break;
                }
            }
            if (isKeyFound)
                return key;
            else
                throw new Exception("Can't Convert Value to Key. Dictionary: " + dict.ToString() + ". Value: " + val.ToString());
        }

        public static AdType RewardToAdType(RewardType reward)
        {
            return ValueBuyKey<RewardType, AdType>(_RewardToAdType, reward);
        }

        public static RewardType AdTypeToReward(AdType reward)
        {
            return KeyByValue<RewardType, AdType>(_RewardToAdType, reward);
        }

        public static RewardType BoosterToReward(BoosterType booster)
        {
            return ValueBuyKey<BoosterType, RewardType>(_boosterToReward, booster);
        }

        public static int BallValueToRealValue(int value)
        {
            return (int)UnityEngine.Mathf.Pow(2, value + 1);
        }
    }
}
