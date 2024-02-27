# Original Online Payment Transaction System

## Motivation
I initiated this project with the following learning objectives:
- Acquiring proficiency in C# programming.
- Understanding different technologies.
- Gaining hands-on experience across various software project roles, including requirement gathering, screen and database design, implementation, testing, deployment, and support.
- Prioritizing exposure to diverse technologies over exploring additional engineering practices to focus on foundational learning.

## Overview
The **Original Online Payment Transaction System** is a C# application designed to streamline the payment processing workflow within the online payment department. It facilitates the handling of various tax payments, including real property tax, business application tax, and miscellaneous taxes, by providing a comprehensive platform for monitoring payment statuses and assisting departmental staff in the tax payment process.

### Stages of Tax Processing:
1. **Verification:**
   - Confirming the entry of payments into the system. Staff input payment data from various sources, such as banks, GCash, and Paymaya, into the system for further processing.

2. **Validation:**
   - Updating the system to reflect the receipt of payments by the department. Verifiers cross-check payments received from other systems and update the system accordingly.

3. **Encoding:**
   - Dedicated to encoding tax payments received from different sources. Payments from banks and electronic platforms like GCash and Paymaya are entered into the system by departmental staff.

4. **Official Receipt Issuance:**
   - Generating official receipts upon successful validation of payments. Tax collectors utilize this feature to tag generated official receipts, indicating completion of the validation process.

5. **Official Receipt Upload:**
   - Scanning receipts, securely storing them in the database, and automatically sending them to taxpayers via email. Staff update information regarding the physical storage location of receipts for easy retrieval.

6. **Releasing:**
   - Assisting staff when taxpayers claim their physical receipts. The system aids in locating the group of taxes associated with a particular taxpayer and provides information on the cabinet and folder containing the physical copies for retrieval.

By efficiently managing the tax payment workflow, the **Original Online Payment Transaction System** enhances the productivity of the online payment department and ensures smoother processing of tax payments.

## Code Statistics

Using `cloc`, the following statistics were generated:

```markdown
------------------------------------------------------------------------------------
Language                          files          blank        comment           code
------------------------------------------------------------------------------------
XML                                 124          26205            401         785432
C#                                   83           2119           1210          10799
C# Designer                          31            189           2652           7268
Text                                 16            663              0           2298
Markdown                              5            254              1            684
MSBuild script                        1              0              0            592
SQL                                   3              6              0             83
Visual Studio Solution                1              1              1             23
------------------------------------------------------------------------------------
SUM:                                264          29437           4265         807179
------------------------------------------------------------------------------------
