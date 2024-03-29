﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Spatial.DbGeometry
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Data.Entity.Resources;
using System.Data.Entity.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Data.Entity.Spatial
{
  /// <summary>Represents geometric shapes.</summary>
  [DataContract]
  [Serializable]
  public class DbGeometry
  {
    private DbSpatialServices _spatialProvider;
    private object _providerValue;

    internal DbGeometry()
    {
    }

    internal DbGeometry(DbSpatialServices spatialServices, object spatialProviderValue)
    {
      this._spatialProvider = spatialServices;
      this._providerValue = spatialProviderValue;
    }

    /// <summary> Gets the default coordinate system id (SRID) for geometry values. </summary>
    /// <returns>The default coordinate system id (SRID) for geometry values.</returns>
    public static int DefaultCoordinateSystemId
    {
      get
      {
        return 0;
      }
    }

    /// <summary> Gets a representation of this DbGeometry value that is specific to the underlying provider that constructed it. </summary>
    /// <returns>A representation of this DbGeometry value.</returns>
    public object ProviderValue
    {
      get
      {
        return this._providerValue;
      }
    }

    /// <summary>
    /// Gets the spatial provider that will be used for operations on this spatial type.
    /// </summary>
    public virtual DbSpatialServices Provider
    {
      get
      {
        return this._spatialProvider;
      }
    }

    /// <summary> Gets or sets a data contract serializable well known representation of this DbGeometry value. </summary>
    /// <returns>A data contract serializable well known representation of this DbGeometry value.</returns>
    [DataMember(Name = "Geometry")]
    public DbGeometryWellKnownValue WellKnownValue
    {
      get
      {
        return this._spatialProvider.CreateWellKnownValue(this);
      }
      set
      {
        if (this._spatialProvider != null)
          throw new InvalidOperationException(Strings.Spatial_WellKnownValueSerializationPropertyNotDirectlySettable);
        DbSpatialServices dbSpatialServices = DbSpatialServices.Default;
        this._providerValue = dbSpatialServices.CreateProviderValue(value);
        this._spatialProvider = dbSpatialServices;
      }
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified well known binary value.
    /// </summary>
    /// <returns>
    /// A new DbGeometry value as defined by the well known binary value with the default geometry coordinate system identifier (
    /// <see cref="P:System.Data.Entity.Spatial.DbGeometry.DefaultCoordinateSystemId" />
    /// ).
    /// </returns>
    /// <param name="wellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <exception cref="T:System.ArgumentNullException">wellKnownBinary</exception>
    public static DbGeometry FromBinary(byte[] wellKnownBinary)
    {
      Check.NotNull<byte[]>(wellKnownBinary, nameof (wellKnownBinary));
      return DbSpatialServices.Default.GeometryFromBinary(wellKnownBinary);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified well known binary value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known binary value with the specified coordinate system identifier.</returns>
    /// <param name="wellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">wellKnownBinary</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry FromBinary(byte[] wellKnownBinary, int coordinateSystemId)
    {
      Check.NotNull<byte[]>(wellKnownBinary, nameof (wellKnownBinary));
      return DbSpatialServices.Default.GeometryFromBinary(wellKnownBinary, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> line value based on the specified well known binary value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known binary value with the specified coordinate system identifier.</returns>
    /// <param name="lineWellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">lineWellKnownBinary</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry LineFromBinary(
      byte[] lineWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(lineWellKnownBinary, nameof (lineWellKnownBinary));
      return DbSpatialServices.Default.GeometryLineFromBinary(lineWellKnownBinary, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> point value based on the specified well known binary value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known binary value with the specified coordinate system identifier.</returns>
    /// <param name="pointWellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">pointWellKnownBinary</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry PointFromBinary(
      byte[] pointWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(pointWellKnownBinary, nameof (pointWellKnownBinary));
      return DbSpatialServices.Default.GeometryPointFromBinary(pointWellKnownBinary, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> polygon value based on the specified well known binary value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known binary value with the specified coordinate system identifier.</returns>
    /// <param name="polygonWellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">polygonWellKnownBinary</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry PolygonFromBinary(
      byte[] polygonWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(polygonWellKnownBinary, nameof (polygonWellKnownBinary));
      return DbSpatialServices.Default.GeometryPolygonFromBinary(polygonWellKnownBinary, coordinateSystemId);
    }

    /// <summary>Returns the multiline value from a binary value.</summary>
    /// <returns>The multiline value from a binary value.</returns>
    /// <param name="multiLineWellKnownBinary">The well-known binary value.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "multiLine")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "MultiLine")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    public static DbGeometry MultiLineFromBinary(
      byte[] multiLineWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(multiLineWellKnownBinary, nameof (multiLineWellKnownBinary));
      return DbSpatialServices.Default.GeometryMultiLineFromBinary(multiLineWellKnownBinary, coordinateSystemId);
    }

    /// <summary>Returns the multipoint value from a well-known binary value.</summary>
    /// <returns>The multipoint value from a well-known binary value.</returns>
    /// <param name="multiPointWellKnownBinary">The well-known binary value.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "MultiPoint")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "multiPoint")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    public static DbGeometry MultiPointFromBinary(
      byte[] multiPointWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(multiPointWellKnownBinary, nameof (multiPointWellKnownBinary));
      return DbSpatialServices.Default.GeometryMultiPointFromBinary(multiPointWellKnownBinary, coordinateSystemId);
    }

    /// <summary>Returns the multi polygon value from a well-known binary value.</summary>
    /// <returns>The multipoint value from a well-known text value.</returns>
    /// <param name="multiPolygonWellKnownBinary">The multi polygon well-known text value.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    public static DbGeometry MultiPolygonFromBinary(
      byte[] multiPolygonWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(multiPolygonWellKnownBinary, nameof (multiPolygonWellKnownBinary));
      return DbSpatialServices.Default.GeometryMultiPolygonFromBinary(multiPolygonWellKnownBinary, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> collection value based on the specified well known binary value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known binary value with the specified coordinate system identifier.</returns>
    /// <param name="geometryCollectionWellKnownBinary">A byte array that contains a well known binary representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">geometryCollectionWellKnownBinary</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry GeometryCollectionFromBinary(
      byte[] geometryCollectionWellKnownBinary,
      int coordinateSystemId)
    {
      Check.NotNull<byte[]>(geometryCollectionWellKnownBinary, nameof (geometryCollectionWellKnownBinary));
      return DbSpatialServices.Default.GeometryCollectionFromBinary(geometryCollectionWellKnownBinary, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified Geography Markup Language (GML) value.
    /// </summary>
    /// <returns>
    /// A new DbGeometry value as defined by the GML value with the default geometry coordinate system identifier (SRID) (
    /// <see cref="P:System.Data.Entity.Spatial.DbGeometry.DefaultCoordinateSystemId" />
    /// ).
    /// </returns>
    /// <param name="geometryMarkup">A string that contains a Geography Markup Language (GML) representation of the geometry value.</param>
    /// <exception cref="T:System.ArgumentNullException">geometryMarkup</exception>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gml")]
    public static DbGeometry FromGml(string geometryMarkup)
    {
      Check.NotNull<string>(geometryMarkup, nameof (geometryMarkup));
      return DbSpatialServices.Default.GeometryFromGml(geometryMarkup);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified Geography Markup Language (GML) value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the GML value with the specified coordinate system identifier.</returns>
    /// <param name="geometryMarkup">A string that contains a Geography Markup Language (GML) representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">geometryMarkup</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gml")]
    public static DbGeometry FromGml(string geometryMarkup, int coordinateSystemId)
    {
      Check.NotNull<string>(geometryMarkup, nameof (geometryMarkup));
      return DbSpatialServices.Default.GeometryFromGml(geometryMarkup, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified well known text value.
    /// </summary>
    /// <returns>
    /// A new DbGeometry value as defined by the well known text value with the default geometry coordinate system identifier (SRID) (
    /// <see cref="P:System.Data.Entity.Spatial.DbGeometry.DefaultCoordinateSystemId" />
    /// ).
    /// </returns>
    /// <param name="wellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <exception cref="T:System.ArgumentNullException">wellKnownText</exception>
    public static DbGeometry FromText(string wellKnownText)
    {
      Check.NotNull<string>(wellKnownText, nameof (wellKnownText));
      return DbSpatialServices.Default.GeometryFromText(wellKnownText);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value based on the specified well known text value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known text value with the specified coordinate system identifier.</returns>
    /// <param name="wellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">wellKnownText</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry FromText(string wellKnownText, int coordinateSystemId)
    {
      Check.NotNull<string>(wellKnownText, nameof (wellKnownText));
      return DbSpatialServices.Default.GeometryFromText(wellKnownText, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> line value based on the specified well known text value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known text value with the specified coordinate system identifier.</returns>
    /// <param name="lineWellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">lineWellKnownText</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry LineFromText(
      string lineWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(lineWellKnownText, nameof (lineWellKnownText));
      return DbSpatialServices.Default.GeometryLineFromText(lineWellKnownText, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> point value based on the specified well known text value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known text value with the specified coordinate system identifier.</returns>
    /// <param name="pointWellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">pointWellKnownText</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry PointFromText(
      string pointWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(pointWellKnownText, nameof (pointWellKnownText));
      return DbSpatialServices.Default.GeometryPointFromText(pointWellKnownText, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> polygon value based on the specified well known text value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known text value with the specified coordinate system identifier.</returns>
    /// <param name="polygonWellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">polygonWellKnownText</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry PolygonFromText(
      string polygonWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(polygonWellKnownText, nameof (polygonWellKnownText));
      return DbSpatialServices.Default.GeometryPolygonFromText(polygonWellKnownText, coordinateSystemId);
    }

    /// <summary>Returns the multiline value from a well-known text value.</summary>
    /// <returns>The multiline value from a well-known text value.</returns>
    /// <param name="multiLineWellKnownText">The well-known text.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "MultiLine")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "multiLine")]
    public static DbGeometry MultiLineFromText(
      string multiLineWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(multiLineWellKnownText, nameof (multiLineWellKnownText));
      return DbSpatialServices.Default.GeometryMultiLineFromText(multiLineWellKnownText, coordinateSystemId);
    }

    /// <summary>Returns the multipoint value from a well-known text value.</summary>
    /// <returns>The multipoint value from a well-known text value.</returns>
    /// <param name="multiPointWellKnownText">The well-known text value.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "MultiPoint")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Match OGC, EDM", MessageId = "multiPoint")]
    public static DbGeometry MultiPointFromText(
      string multiPointWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(multiPointWellKnownText, nameof (multiPointWellKnownText));
      return DbSpatialServices.Default.GeometryMultiPointFromText(multiPointWellKnownText, coordinateSystemId);
    }

    /// <summary>Returns the multi polygon value from a well-known binary value.</summary>
    /// <returns>The multi polygon value from a well-known binary value.</returns>
    /// <param name="multiPolygonWellKnownText">The multi polygon well-known text value.</param>
    /// <param name="coordinateSystemId">The coordinate system identifier.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "multi")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Match OGC, EDM", MessageId = "Multi")]
    public static DbGeometry MultiPolygonFromText(
      string multiPolygonWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(multiPolygonWellKnownText, nameof (multiPolygonWellKnownText));
      return DbSpatialServices.Default.GeometryMultiPolygonFromText(multiPolygonWellKnownText, coordinateSystemId);
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> collection value based on the specified well known text value and coordinate system identifier (SRID).
    /// </summary>
    /// <returns>A new DbGeometry value as defined by the well known text value with the specified coordinate system identifier.</returns>
    /// <param name="geometryCollectionWellKnownText">A string that contains a well known text representation of the geometry value.</param>
    /// <param name="coordinateSystemId">The identifier of the coordinate system that the new DbGeometry value should use.</param>
    /// <exception cref="T:System.ArgumentNullException">geometryCollectionWellKnownText</exception>
    /// <exception cref="T:System.ArgumentException">coordinateSystemId</exception>
    public static DbGeometry GeometryCollectionFromText(
      string geometryCollectionWellKnownText,
      int coordinateSystemId)
    {
      Check.NotNull<string>(geometryCollectionWellKnownText, nameof (geometryCollectionWellKnownText));
      return DbSpatialServices.Default.GeometryCollectionFromText(geometryCollectionWellKnownText, coordinateSystemId);
    }

    /// <summary>Gets the coordinate system identifier of the DbGeometry object.</summary>
    /// <returns>The coordinate system identifier of the DbGeometry object.</returns>
    public int CoordinateSystemId
    {
      get
      {
        return this._spatialProvider.GetCoordinateSystemId(this);
      }
    }

    /// <summary>Gets the boundary of the DbGeometry objects.</summary>
    /// <returns>The boundary of the DbGeometry objects.</returns>
    public DbGeometry Boundary
    {
      get
      {
        return this._spatialProvider.GetBoundary(this);
      }
    }

    /// <summary>
    /// Gets the dimension of the given <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value or, if the value is a collection, the dimension of its largest element.
    /// </summary>
    /// <returns>
    /// The dimension of the given <see cref="T:System.Data.Entity.Spatial.DbGeometry" /> value.
    /// </returns>
    public int Dimension
    {
      get
      {
        return this._spatialProvider.GetDimension(this);
      }
    }

    /// <summary> Gets the envelope (minimum bounding box) of this DbGeometry value, as a geometry value. </summary>
    /// <returns>The envelope (minimum bounding box) of this DbGeometry value.</returns>
    public DbGeometry Envelope
    {
      get
      {
        return this._spatialProvider.GetEnvelope(this);
      }
    }

    /// <summary>Gets a spatial type name representation of this DbGeometry value.</summary>
    /// <returns>A spatial type name representation of this DbGeometry value.</returns>
    public string SpatialTypeName
    {
      get
      {
        return this._spatialProvider.GetSpatialTypeName(this);
      }
    }

    /// <summary>Gets a nullable Boolean value indicating whether this DbGeometry value is empty, which may be null if this value does not represent a curve.</summary>
    /// <returns>True if this DbGeometry value is empty; otherwise, false.</returns>
    public bool IsEmpty
    {
      get
      {
        return this._spatialProvider.GetIsEmpty(this);
      }
    }

    /// <summary>Gets a nullable Boolean value indicating whether this DbGeometry value is simple.</summary>
    /// <returns>True if this DbGeometry value is simple; otherwise, false.</returns>
    public bool IsSimple
    {
      get
      {
        return this._spatialProvider.GetIsSimple(this);
      }
    }

    /// <summary>Gets a nullable Boolean value indicating whether this DbGeometry value is valid.</summary>
    /// <returns>True if this DbGeometry value is valid; otherwise, false.</returns>
    public bool IsValid
    {
      get
      {
        return this._spatialProvider.GetIsValid(this);
      }
    }

    /// <summary> Generates the well known text representation of this DbGeometry value.  Includes only X and Y coordinates for points. </summary>
    /// <returns>A string containing the well known text representation of this DbGeometry value.</returns>
    public virtual string AsText()
    {
      return this._spatialProvider.AsText(this);
    }

    internal string AsTextIncludingElevationAndMeasure()
    {
      return this._spatialProvider.AsTextIncludingElevationAndMeasure(this);
    }

    /// <summary> Generates the well known binary representation of this DbGeometry value. </summary>
    /// <returns>The well-known binary representation of this DbGeometry value.</returns>
    public byte[] AsBinary()
    {
      return this._spatialProvider.AsBinary(this);
    }

    /// <summary> Generates the Geography Markup Language (GML) representation of this DbGeometry value. </summary>
    /// <returns>A string containing the GML representation of this DbGeometry value.</returns>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gml")]
    public string AsGml()
    {
      return this._spatialProvider.AsGml(this);
    }

    /// <summary> Determines whether this DbGeometry is spatially equal to the specified DbGeometry argument. </summary>
    /// <returns>true if other is spatially equal to this geometry value; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for equality.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool SpatialEquals(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.SpatialEquals(this, other);
    }

    /// <summary> Determines whether this DbGeometry is spatially disjoint from the specified DbGeometry argument. </summary>
    /// <returns>true if other is disjoint from this geometry value; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for disjointness.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Disjoint(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Disjoint(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially intersects the specified DbGeometry argument. </summary>
    /// <returns>true if other intersects this geometry value; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for intersection.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Intersects(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Intersects(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially touches the specified DbGeometry argument. </summary>
    /// <returns>true if other touches this geometry value; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Touches(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Touches(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially crosses the specified DbGeometry argument. </summary>
    /// <returns>true if other crosses this geometry value; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Crosses(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Crosses(this, other);
    }

    /// <summary> Determines whether this DbGeometry value is spatially within the specified DbGeometry argument. </summary>
    /// <returns>true if this geometry value is within other; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for containment.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Within(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Within(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially contains the specified DbGeometry argument. </summary>
    /// <returns>true if this geometry value contains other; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for containment.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Contains(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Contains(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially overlaps the specified DbGeometry argument. </summary>
    /// <returns>true if this geometry value overlaps other; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for overlap.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public bool Overlaps(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Overlaps(this, other);
    }

    /// <summary> Determines whether this DbGeometry value spatially relates to the specified DbGeometry argument according to the given Dimensionally Extended Nine-Intersection Model (DE-9IM) intersection pattern. </summary>
    /// <returns>true if this geometry value relates to other according to the specified intersection pattern matrix; otherwise false.</returns>
    /// <param name="other">The geometry value that should be compared with this geometry value for relation.</param>
    /// <param name="matrix">A string that contains the text representation of the (DE-9IM) intersection pattern that defines the relation.</param>
    /// <exception cref="T:System.ArgumentNullException">othermatrix</exception>
    public bool Relate(DbGeometry other, string matrix)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      Check.NotNull<string>(matrix, nameof (matrix));
      return this._spatialProvider.Relate(this, other, matrix);
    }

    /// <summary>Returns a geometry object that represents the union of all points whose distance from a geometry instance is less than or equal to a specified value.</summary>
    /// <returns>A geometry object that represents the union of all points.</returns>
    /// <param name="distance">The distance.</param>
    public DbGeometry Buffer(double? distance)
    {
      Check.NotNull<double>(distance, nameof (distance));
      return this._spatialProvider.Buffer(this, distance.Value);
    }

    /// <summary> Computes the distance between the closest points in this DbGeometry value and another DbGeometry value. </summary>
    /// <returns>A double value that specifies the distance between the two closest points in this geometry value and other.</returns>
    /// <param name="other">The geometry value for which the distance from this value should be computed.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public double? Distance(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return new double?(this._spatialProvider.Distance(this, other));
    }

    /// <summary> Gets the convex hull of this DbGeometry value as another DbGeometry value. </summary>
    /// <returns>The convex hull of this DbGeometry value as another DbGeometry value.</returns>
    public DbGeometry ConvexHull
    {
      get
      {
        return this._spatialProvider.GetConvexHull(this);
      }
    }

    /// <summary> Computes the intersection of this DbGeometry value and another DbGeometry value. </summary>
    /// <returns>A new DbGeometry value representing the intersection between this geometry value and other.</returns>
    /// <param name="other">The geometry value for which the intersection with this value should be computed.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public DbGeometry Intersection(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Intersection(this, other);
    }

    /// <summary> Computes the union of this DbGeometry value and another DbGeometry value. </summary>
    /// <returns>A new DbGeometry value representing the union between this geometry value and other.</returns>
    /// <param name="other">The geometry value for which the union with this value should be computed.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public DbGeometry Union(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Union(this, other);
    }

    /// <summary> Computes the difference between this DbGeometry value and another DbGeometry value. </summary>
    /// <returns>A new DbGeometry value representing the difference between this geometry value and other.</returns>
    /// <param name="other">The geometry value for which the difference with this value should be computed.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public DbGeometry Difference(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.Difference(this, other);
    }

    /// <summary> Computes the symmetric difference between this DbGeometry value and another DbGeometry value. </summary>
    /// <returns>A new DbGeometry value representing the symmetric difference between this geometry value and other.</returns>
    /// <param name="other">The geometry value for which the symmetric difference with this value should be computed.</param>
    /// <exception cref="T:System.ArgumentNullException">other</exception>
    public DbGeometry SymmetricDifference(DbGeometry other)
    {
      Check.NotNull<DbGeometry>(other, nameof (other));
      return this._spatialProvider.SymmetricDifference(this, other);
    }

    /// <summary> Gets the number of elements in this DbGeometry value, if it represents a geometry collection. &lt;returns&gt;The number of elements in this geometry value, if it represents a collection of other geometry values; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The number of elements in this DbGeometry value.</returns>
    public int? ElementCount
    {
      get
      {
        return this._spatialProvider.GetElementCount(this);
      }
    }

    /// <summary> Returns an element of this DbGeometry value from a specific position, if it represents a geometry collection. &lt;param name="index"&gt;The position within this geometry value from which the element should be taken.&lt;/param&gt;&lt;returns&gt;The element in this geometry value at the specified position, if it represents a collection of other geometry values; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>An element of this DbGeometry value from a specific position.</returns>
    /// <param name="index">The index.</param>
    public DbGeometry ElementAt(int index)
    {
      return this._spatialProvider.ElementAt(this, index);
    }

    /// <summary> Gets the X coordinate of this DbGeometry value, if it represents a point. &lt;returns&gt;The X coordinate value of this geometry value, if it represents a point; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The X coordinate of this DbGeometry value.</returns>
    public double? XCoordinate
    {
      get
      {
        return this._spatialProvider.GetXCoordinate(this);
      }
    }

    /// <summary> Gets the Y coordinate of this DbGeometry value, if it represents a point. &lt;returns&gt;The Y coordinate value of this geometry value, if it represents a point; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The Y coordinate of this DbGeometry value.</returns>
    public double? YCoordinate
    {
      get
      {
        return this._spatialProvider.GetYCoordinate(this);
      }
    }

    /// <summary> Gets the elevation (Z coordinate) of this DbGeometry value, if it represents a point. &lt;returns&gt;The elevation (Z coordinate) of this geometry value, if it represents a point; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The elevation (Z coordinate) of this DbGeometry value.</returns>
    public double? Elevation
    {
      get
      {
        return this._spatialProvider.GetElevation(this);
      }
    }

    /// <summary> Gets the Measure (M coordinate) of this DbGeometry value, if it represents a point. &lt;returns&gt;The Measure (M coordinate) value of this geometry value, if it represents a point; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The Measure (M coordinate) of this DbGeometry value.</returns>
    public double? Measure
    {
      get
      {
        return this._spatialProvider.GetMeasure(this);
      }
    }

    /// <summary> Gets a nullable double value that indicates the length of this DbGeometry value, which may be null if this value does not represent a curve. </summary>
    /// <returns>The length of this DbGeometry value.</returns>
    public double? Length
    {
      get
      {
        return this._spatialProvider.GetLength(this);
      }
    }

    /// <summary> Gets a DbGeometry value representing the start point of this value, which may be null if this DbGeometry value does not represent a curve. </summary>
    /// <returns>A DbGeometry value representing the start point of this value.</returns>
    public DbGeometry StartPoint
    {
      get
      {
        return this._spatialProvider.GetStartPoint(this);
      }
    }

    /// <summary> Gets a DbGeometry value representing the start point of this value, which may be null if this DbGeometry value does not represent a curve. </summary>
    /// <returns>A DbGeometry value representing the start point of this value.</returns>
    public DbGeometry EndPoint
    {
      get
      {
        return this._spatialProvider.GetEndPoint(this);
      }
    }

    /// <summary> Gets a nullable Boolean value indicating whether this DbGeometry value is closed, which may be null if this value does not represent a curve. </summary>
    /// <returns>True if this DbGeometry value is closed; otherwise, false.</returns>
    public bool? IsClosed
    {
      get
      {
        return this._spatialProvider.GetIsClosed(this);
      }
    }

    /// <summary> Gets a nullable Boolean value indicating whether this DbGeometry value is a ring, which may be null if this value does not represent a curve. </summary>
    /// <returns>True if this DbGeometry value is a ring; otherwise, false.</returns>
    public bool? IsRing
    {
      get
      {
        return this._spatialProvider.GetIsRing(this);
      }
    }

    /// <summary> Gets the number of points in this DbGeometry value, if it represents a linestring or linear ring. &lt;returns&gt;The number of elements in this geometry value, if it represents a linestring or linear ring; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The number of points in this DbGeometry value.</returns>
    public int? PointCount
    {
      get
      {
        return this._spatialProvider.GetPointCount(this);
      }
    }

    /// <summary> Returns an element of this DbGeometry value from a specific position, if it represents a linestring or linear ring. &lt;param name="index"&gt;The position within this geometry value from which the element should be taken.&lt;/param&gt;&lt;returns&gt;The element in this geometry value at the specified position, if it represents a linestring or linear ring; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>An element of this DbGeometry value from a specific position.</returns>
    /// <param name="index">The index.</param>
    public DbGeometry PointAt(int index)
    {
      return this._spatialProvider.PointAt(this, index);
    }

    /// <summary> Gets a nullable double value that indicates the area of this DbGeometry value, which may be null if this value does not represent a surface. </summary>
    /// <returns>A nullable double value that indicates the area of this DbGeometry value.</returns>
    public double? Area
    {
      get
      {
        return this._spatialProvider.GetArea(this);
      }
    }

    /// <summary> Gets the DbGeometry value that represents the centroid of this DbGeometry value, which may be null if this value does not represent a surface. </summary>
    /// <returns>The DbGeometry value that represents the centroid of this DbGeometry value.</returns>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Naming convention prescribed by OGC specification", MessageId = "Centroid")]
    public DbGeometry Centroid
    {
      get
      {
        return this._spatialProvider.GetCentroid(this);
      }
    }

    /// <summary> Gets a point on the surface of this DbGeometry value, which may be null if this value does not represent a surface. </summary>
    /// <returns>A point on the surface of this DbGeometry value.</returns>
    public DbGeometry PointOnSurface
    {
      get
      {
        return this._spatialProvider.GetPointOnSurface(this);
      }
    }

    /// <summary> Gets the DbGeometry value that represents the exterior ring of this DbGeometry value, which may be null if this value does not represent a polygon. </summary>
    /// <returns>The DbGeometry value that represents the exterior ring of this DbGeometry value.</returns>
    public DbGeometry ExteriorRing
    {
      get
      {
        return this._spatialProvider.GetExteriorRing(this);
      }
    }

    /// <summary> Gets the number of interior rings in this DbGeometry value, if it represents a polygon. &lt;returns&gt;The number of elements in this geometry value, if it represents a polygon; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>The number of interior rings in this DbGeometry value.</returns>
    public int? InteriorRingCount
    {
      get
      {
        return this._spatialProvider.GetInteriorRingCount(this);
      }
    }

    /// <summary> Returns an interior ring from this DbGeometry value at a specific position, if it represents a polygon. &lt;param name="index"&gt;The position within this geometry value from which the interior ring should be taken.&lt;/param&gt;&lt;returns&gt;The interior ring in this geometry value at the specified position, if it represents a polygon; otherwise null.&lt;/returns&gt;</summary>
    /// <returns>An interior ring from this DbGeometry value at a specific position.</returns>
    /// <param name="index">The index.</param>
    public DbGeometry InteriorRingAt(int index)
    {
      return this._spatialProvider.InteriorRingAt(this, index);
    }

    /// <summary> Returns a string representation of the geometry value. </summary>
    /// <returns>A string representation of the geometry value.</returns>
    public override string ToString()
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "SRID={1};{0}", (object) (this.WellKnownValue.WellKnownText ?? base.ToString()), (object) this.CoordinateSystemId);
    }
  }
}
