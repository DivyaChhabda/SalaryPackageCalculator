async function calculateSalary() {

    debugger;
    const employee = {
        CompanyType: document.getElementById("companyType").value,
        EmploymentType: document.getElementById("employmentType").value,
        Salary: parseFloat(document.getElementById("salary").value),
        HoursWorked: parseInt(document.getElementById("hoursWorked").value || "0"),
        IsEducated: document.getElementById("isEducated").checked
    };

    const response = await fetch("/api/SalaryPackaging", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(employee)
    });

    if (response.ok) {
        const data = await response.json();
        document.getElementById("result").textContent = `$${data.limit}`;
    } else {
        document.getElementById("result").textContent = "Error calculating salary packaging.";
    }
}
