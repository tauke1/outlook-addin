# outlook-addin
## This addins helps to convert Outlook email messages to Azure DevOps Work Items 
## How to use this add-in
1) if you dont have an installer, then clone this repository, publish it on Visual Studio by Build tab -> Publish
2) run installer, Azure Devops button group will appear in right side of Main tab of Mail View
3) Setup settings by Settings button
   3.1) Organization Name - name of your Azure Devops organization
   3.2) Project Name - name of project which you want add work items
   3.3) Pat Token - access token with rights to create work items, comments, add-attachments, you can create PAT token in user settings
   3.4) Category by source field name - custom fields of work item, it should be picklist
   3.5) Category by complexity field name - custom fields of work item, it should be picklist
   3.6) Work Item Type - default work item type which will be assigned in each work item creation
   3.7) Default category by source - default value of category by source field - dropdownlist
4) Click Azure Devops button and wait if there are works items with the same title as current message subject
5) If another work items exist, then you can add comment to it, or just create new work item in any case



