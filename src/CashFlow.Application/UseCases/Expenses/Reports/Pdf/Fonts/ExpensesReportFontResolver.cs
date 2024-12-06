using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        throw new NotImplementedException();
    }

    public byte[]? GetFont(string faceName)
    {
        throw new NotImplementedException();
    }
}