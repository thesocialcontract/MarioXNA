using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public static class ContextSelector
    {
        private struct Context {
            public Type context;
            public float weight;

            public Context(Type con, float weight)
            {
                context = con;
                this.weight = weight;
            }
        };

        private static List<Context> contexts = new List<Context>()
        {
            new Context(typeof(HorizontalChallengeContext), 1.0f/3.0f),
            new Context(typeof(VerticalChallengeContext), 1.0f/3.0f),
            new Context(typeof(RiskRewardContext), 1.0f/3.0f)
        };

        private static void SetWeights(Context candidate)
        {
            var deltaWeightCand = candidate.weight / contexts.Count;
            var deltaWeightOthers = deltaWeightCand / (contexts.Count - 1);
            for (int i = 0; i < contexts.Count; i++)
            {
                if (contexts[i].context == candidate.context)
                    contexts[i] = new Context(contexts[i].context, contexts[i].weight - deltaWeightCand);
                else
                    contexts[i] = new Context(contexts[i].context, contexts[i].weight + deltaWeightOthers);
            }
            contexts.Sort((x, y) => x.weight.CompareTo(y.weight));
        }
        
        public static IGameplayContext SelectRandomContext()
        {
            Type context = null;
            var rand = new Random();
            double diceRoll = rand.NextDouble();
            double cumulative = 0.0;
            foreach(var candidate in contexts)
            {
                cumulative += candidate.weight;
                if (diceRoll < cumulative)
                {
                    context = candidate.context;
                    SetWeights(candidate);
                    break;
                }
            }
            return (IGameplayContext)Activator.CreateInstance(context);
        }
    }
}
