using System.Collections.Generic;
using Yolov7net;

namespace Yolov7net.Models.Abstract
{
    /// <summary>
    /// Model descriptor.
    /// </summary>
    public abstract class YoloModelAbstract
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int Depth { get; }

        public abstract int Dimensions { get; }

        public abstract float[] Strides { get; }
        public abstract float[][][] Anchors { get; }
        public abstract int[] Shapes { get; }

        public abstract float Confidence { get; }
        public abstract float MulConfidence { get; }
        public abstract float Overlap { get; }

        public abstract string[] OutputNames { get; }

        public abstract bool UseDetect { get; }

        public abstract string Weights { get; }

        public List<YoloLabel> Labels { get; protected set; }

        public bool Ready { get; set; }
    }
}
