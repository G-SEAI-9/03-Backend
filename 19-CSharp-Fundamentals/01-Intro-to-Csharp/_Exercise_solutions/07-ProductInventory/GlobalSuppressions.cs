// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Style",
    "IDE0130:Namespace does not match folder structure",
    Justification = "<Pending>",
    Scope = "namespace",
    Target = "~N:Controllers"
)]
[assembly: SuppressMessage(
    "Style",
    "IDE0130:Namespace does not match folder structure",
    Justification = "<Pending>",
    Scope = "namespace",
    Target = "~N:Helpers"
)]
[assembly: SuppressMessage(
    "Style",
    "IDE0130:Namespace does not match folder structure",
    Justification = "<Pending>",
    Scope = "namespace",
    Target = "~N:Models"
)]
[assembly: SuppressMessage(
    "Style",
    "IDE0130:Namespace does not match folder structure",
    Justification = "<Pending>",
    Scope = "namespace",
    Target = "~N:Services"
)]
[assembly: SuppressMessage(
    "Style",
    "IDE0130:Namespace does not match folder structure",
    Justification = "<Pending>",
    Scope = "namespace",
    Target = "~N:UI"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Controllers.ProductController.FindByName"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Controllers.ProductController.GetById"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Controllers.ProductController.ListProduct"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Helpers.InputUtils.ReadDecimal(System.String,System.Decimal,System.Decimal)~System.Decimal"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Helpers.InputUtils.ReadInt(System.String,System.Int32,System.Int32)~System.Int32"
)]
[assembly: SuppressMessage(
    "Usage",
    "MA0011:IFormatProvider is missing",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Helpers.InputUtils.ReadDecimal(System.String,System.Decimal,System.Decimal)~System.Decimal"
)]
[assembly: SuppressMessage(
    "Usage",
    "MA0011:IFormatProvider is missing",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Helpers.InputUtils.ReadInt(System.String,System.Int32,System.Int32)~System.Int32"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Services.ProductDb.Add(Models.Product)"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Services.ProductDb.Add(System.Collections.Generic.IEnumerable{Models.Product})"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Services.ProductDb.FindByName(System.String)~Models.Product"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Services.ProductDb.GetById(System.Guid)~Models.Product"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:Services.ProductDb.Remove(System.Guid)~System.Boolean"
)]
[assembly: SuppressMessage(
    "Design",
    "MA0025:Implement the functionality instead of throwing NotImplementedException",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~P:Services.ProductDb.Products"
)]
[assembly: SuppressMessage(
    "Performance",
    "CA1852:Seal internal types",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:UI.Menu"
)]
[assembly: SuppressMessage(
    "Performance",
    "CA1852:Seal internal types",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Controllers.ProductController"
)]
[assembly: SuppressMessage(
    "Performance",
    "CA1852:Seal internal types",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Services.ProductInventoryService"
)]
[assembly: SuppressMessage(
    "Performance",
    "CA1852:Seal internal types",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Helpers.InputUtils"
)]
[assembly: SuppressMessage(
    "Performance",
    "CA1852:Seal internal types",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Services.ProductDb"
)]
