using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MdsLibrary.Model
{
    public class AccData
    {
        [JsonProperty("Body")]
        public Body Data;

        public AccData(Body body)
        {
            this.Data = body;
        }

        /// <summary>
        /// Data for Accelerometer readings
        /// </summary>
        public class Body
        {
            /// <summary>
            /// Local timestamp of first measurement in the array of readings
            /// </summary>
            [JsonProperty("Timestamp")]
            public long Timestamp;

            /// <summary>
            /// Array of Accelerometer readings
            /// </summary>
            [JsonProperty("ArrayAcc")]
            public AccDataArray[] AccData;

            /// <summary>
            /// Headers
            /// </summary>
            [JsonProperty("Headers")]
            public Headers Header;

            /// <summary>
            /// Constructs an Accelerometer Readings object
            /// </summary>
            /// <param name="timestamp">Local timestamp of first measurement in the array of readings</param>
            /// <param name="array">Array of Accelerometer readings</param>
            /// <param name="header">Headers</param>
            public Body(long timestamp, AccDataArray[] array, Headers header)
            {
                this.Timestamp = timestamp;
                this.AccData = array;
                this.Header = header;
            }
        }

        /// <summary>
        /// Array of Accelerometer readings
        /// </summary>
        public class AccDataArray
        {
            /// <summary>
            /// X value
            /// </summary>
            [JsonProperty("x")]
            public double X;

            /// <summary>
            /// Y value
            /// </summary>
            [JsonProperty("y")]
            public double Y;

            /// <summary>
            /// Z value
            /// </summary>
            [JsonProperty("z")]
            public double Z;

            /// <summary>
            /// Constructs an AccDataArray
            /// </summary>
            /// <param name="x">X value</param>
            /// <param name="y">Y value</param>
            /// <param name="z">Z value</param>
            public AccDataArray(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        public class Headers
        {
            [JsonProperty("Param0")]
            public int Param0;

            public Headers(int param0)
            {
                this.Param0 = param0;
            }
        }
    }

}
