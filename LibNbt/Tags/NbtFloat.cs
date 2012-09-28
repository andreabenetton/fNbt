﻿using System;
using System.Text;
using JetBrains.Annotations;

namespace LibNbt {
    /// <summary> A tag containing a single single-precision floating point number. </summary>
    public sealed class NbtFloat : NbtTag, INbtTagValue<float> {
        public override NbtTagType TagType {
            get { return NbtTagType.Float; }
        }

        public float Value { get; set; }


        public NbtFloat()
            : this( null ) {}


        public NbtFloat( float value )
            : this( null, value ) {}


        public NbtFloat( [CanBeNull] string tagName )
            : this( tagName, 0 ) {}


        public NbtFloat( [CanBeNull] string tagName, float value ) {
            Name = tagName;
            Value = value;
        }


        internal void ReadTag( NbtReader readStream, bool readName ) {
            if( readName ) {
                Name = readStream.ReadString();
            }
            Value = readStream.ReadSingle();
        }


        internal override void WriteTag( NbtWriter writeStream, bool writeName ) {
            writeStream.Write( NbtTagType.Float );
            if( writeName ) {
                if( Name == null ) throw new NullReferenceException( "Name is null" );
                writeStream.Write( Name );
            }
            writeStream.Write( Value );
        }


        internal override void WriteData( NbtWriter writeStream ) {
            writeStream.Write( Value );
        }


        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append( "TAG_Float" );
            if( !String.IsNullOrEmpty( Name ) ) {
                sb.AppendFormat( "(\"{0}\")", Name );
            }
            sb.AppendFormat( ": {0}", Value );
            return sb.ToString();
        }
    }
}