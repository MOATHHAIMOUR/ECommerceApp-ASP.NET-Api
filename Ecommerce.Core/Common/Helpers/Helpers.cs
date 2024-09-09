namespace Ecommerce.Application.Common.Helpers
{
    public static class Helpers
    {
        public static Dictionary<string, string> ConstructDic(string sotrs)
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            // // Id DESE,Name DESE
            string[] PropsPerValuesArray = sotrs.Split(',');

            foreach (string PropPerValue in PropsPerValuesArray)
            {
                // Id DESE
                string[] PropPerValueArray = PropPerValue.Split(' ');
                //Id
                string Prop = PropPerValueArray[0];
                //DESE
                string Value = PropPerValueArray[1];

                keyValuePairs.Add(Prop, Value);
            }

            return keyValuePairs;
        }

    }
}
