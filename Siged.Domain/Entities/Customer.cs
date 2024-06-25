using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? IdentificationCard { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }
}
